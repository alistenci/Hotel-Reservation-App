using AutoMapper;
using eHotelApp.Application.Features.Reservations.AddReservations;
using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class AddReservationsQueryHandler(IUnitOfWork unitOfWork, IReservationsRepository reservationsRepository, IHotelRoomsRepository hotelRoomsRepository) : IRequestHandler<AddReservationsQuery, Result<string>>
{
    public async Task<Result<string>> Handle(AddReservationsQuery request, CancellationToken cancellationToken)
    {
        HotelRooms hotelRooms = await hotelRoomsRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.RoomId, cancellationToken);

        if (request.CheckInDate.Date.ToUniversalTime() >= request.CheckOutDate.Date.ToUniversalTime())
        {
            return Result<string>.Failure("Başlangıç tarihi bitiş tarihinden sonra olamaz!");
        }


        if (request.CheckInDate.Date.ToUniversalTime() > DateTime.UtcNow.AddDays(1))
        {
            hotelRooms.isAvailable = true;
        }
        else
        {
            hotelRooms.isAvailable = false;
        }


        DateTime startDate = Convert.ToDateTime(request.CheckInDate).ToUniversalTime();
        DateTime endDate = Convert.ToDateTime(request.CheckOutDate).ToUniversalTime();

        bool isRoomBooked = await reservationsRepository.GetAll()
            .AnyAsync(reservation =>
                reservation.RoomId == hotelRooms.Id &&
                (
                    (startDate < reservation.CheckOutDate && endDate > reservation.CheckInDate) || // Rezervasyon kontrol
                    (endDate > reservation.CheckInDate && endDate <= reservation.CheckOutDate)
                ), cancellationToken);

        if (isRoomBooked)
        {
            return Result<string>.Failure("Seçilen tarihlerde oda dolu!");
        }


        int totalDays = (endDate - startDate).Days;
        decimal totalPrice = totalDays * hotelRooms.price;

        Reservations reservations = new()
        {
            RoomId = request.RoomId,
            TotalPrice = totalPrice,
            Notes = request.notes,
            fullName = request.fullName,
            eMail = request.eMail,
            phoneNumber = request.phoneNumber,
            floorNumber = hotelRooms.floorNumber,
            roomNumber = hotelRooms.roomNumber,
            identityNumber = request.identityNumber,
            CheckInDate = startDate,
            CheckOutDate = endDate,
        };

       
        await reservationsRepository.AddAsync(reservations, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Reservation added successfully");
    }
}
