using eHotelApp.Application.DTO;
using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Reservations.GetReservationsInfoById
{
    public sealed record GetReservationsInfoByIdCommand(Guid Id) : IRequest<Result<List<ReservationInfoDto>>>;
}
