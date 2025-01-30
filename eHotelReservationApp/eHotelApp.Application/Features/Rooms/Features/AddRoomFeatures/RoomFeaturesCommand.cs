using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Features.RoomFeatures
{
    public sealed record RoomFeaturesCommand(string FeatureName) : IRequest<Result<string>>;
}
