using MediatR;
using Microsoft.AspNetCore.Http;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Types.RoomTypes
{
    public sealed record RoomTypesCommand(string TypeName, decimal Price, string ImageURL) : IRequest<Result<string>>;
}
