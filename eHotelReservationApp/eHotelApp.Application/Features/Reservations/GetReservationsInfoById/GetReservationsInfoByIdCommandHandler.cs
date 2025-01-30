using eHotelApp.Application.DTO;
using eHotelApp.Application.Features.Reservations.GetReservationsInfoById;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class GetReservationsInfoByIdCommandHandler(IReservationsRepository reservationsRepository) : IRequestHandler<GetReservationsInfoByIdCommand, Result<List<ReservationInfoDto>>>
{
    public async Task<Result<List<ReservationInfoDto>>> Handle(GetReservationsInfoByIdCommand request, CancellationToken cancellationToken)
    {
        List<Reservations> reservations = await reservationsRepository.Where(p => p.RoomId == request.Id).OrderBy(p => p.CheckInDate).ToListAsync(cancellationToken);

        List<ReservationInfoDto> reservationInfoDtos = reservations.Select(r => new ReservationInfoDto
        {
            CheckInDate = r.CheckInDate.ToString("yyyy-MM-dd"),
            CheckOutDate = r.CheckOutDate.ToString("yyyy-MM-dd")
        }).ToList();

        return Result<List<ReservationInfoDto>>.Succeed(reservationInfoDtos);
    }
}
