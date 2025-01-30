using eHotelApp.Domain.Entities;
using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Rooms.GetAllRooms
{
    public sealed record GetAllRoomsQuery() : IRequest<Result<List<HotelRooms>>>;
}
