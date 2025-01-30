using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Login
{
    public sealed record LoginCommand(string usernameOrEmail, string password) : IRequest<Result<LoginCommandResponse>>;
}
