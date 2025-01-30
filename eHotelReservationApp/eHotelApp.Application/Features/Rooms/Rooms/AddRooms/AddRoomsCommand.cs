using eHotelApp.Domain.Entities;
using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Rooms.AddRooms
{
    public sealed record AddRoomsCommand(
        string RoomName,
        Guid RoomTypeId,
        string Description,
        int minGuests,
        int maxGuests,
        int maxChildren,
        int floorNumber,
        int roomNumber,
        int roomCount,
        decimal price
        ) : IRequest<Result<string>>;
}
