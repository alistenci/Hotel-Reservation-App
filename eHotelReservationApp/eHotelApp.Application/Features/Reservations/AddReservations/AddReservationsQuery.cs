using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Reservations.AddReservations
{
    public sealed record AddReservationsQuery(
        Guid RoomId,
        decimal totalPrice,
        string notes,
        string fullName,
        string eMail,
        string phoneNumber,
        string identityNumber,
        int floorNumber,
        int roomNumber,
        DateTime CheckInDate,
        DateTime CheckOutDate) :IRequest<Result<string>>;
}
