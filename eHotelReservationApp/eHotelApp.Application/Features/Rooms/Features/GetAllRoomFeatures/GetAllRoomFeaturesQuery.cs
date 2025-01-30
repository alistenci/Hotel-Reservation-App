using eHotelApp.Domain.Entities;
using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Features.GetAllRoomFeatures
{
    public sealed record GetAllRoomFeaturesQuery() : IRequest<Result<List<RoomFeature>>>;
}
