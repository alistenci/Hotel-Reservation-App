using eHotelApp.Domain.Entities;
using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Types.GetAllTypes
{
    public sealed record GetAllTypesQuery() : IRequest<Result<List<RoomType>>>;
}
