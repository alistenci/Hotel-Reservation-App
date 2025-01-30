using eHotelApp.Application.Features.Rooms.Rooms.AddRooms;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;
using Microsoft.EntityFrameworkCore;

internal sealed class AddRoomsCommandHandler(IHotelRoomsRepository roomsRepository, IUnitOfWork unitOfWork, IRoomTypeRepository roomTypeRepository) : IRequestHandler<AddRoomsCommand, Result<string>>
{
    public async Task<Result<string>> Handle(AddRoomsCommand request, CancellationToken cancellationToken)
    {
        int totalRoom = await roomsRepository.GetAll().Where(p => p.floorNumber == request.floorNumber).CountAsync();

        // RoomType Id kontrolü
        RoomType? roomType = await roomTypeRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.RoomTypeId, cancellationToken);
        if (roomType is null)
        {
            return Result<string>.Failure("Oda tipi bulunamadı.");
        }

        // Kat doluluk kontrolü
        if (totalRoom >= 100 || totalRoom + request.roomCount > 100)
        {
            return Result<string>.Failure($"Belirtilen katta en fazla 100 oda olabilir. Mevcut oda sayısı: {totalRoom}");
        }

        int lastRoomNumber = totalRoom > 0
            ? await roomsRepository.GetAll().Where(r => r.floorNumber == request.floorNumber)
                .OrderByDescending(r => r.roomNumber)
                .Select(r => r.roomNumber)
                .FirstOrDefaultAsync() + 1
            : request.floorNumber * 100;

        // Odaları ekleme
        for (int i = 0; i < request.roomCount; i++)
        {
            HotelRooms hotelRooms = new()
            {
                RoomName = request.RoomName,
                RoomTypeId = request.RoomTypeId,
                Description = request.Description,
                maxGuests = request.maxGuests,
                minGuests = request.minGuests,
                maxChildren = request.maxChildren,
                floorNumber = request.floorNumber,
                roomNumber = lastRoomNumber + i,
                roomCount = request.roomCount,
                RoomType = roomType.TypeName,
                price = roomType.Price,
                imageURL = roomType.ImageUrl,
                isAvailable = true
            };
            await roomsRepository.AddAsync(hotelRooms, cancellationToken);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Oda ekleme işlemi başarılı.");
    }
}