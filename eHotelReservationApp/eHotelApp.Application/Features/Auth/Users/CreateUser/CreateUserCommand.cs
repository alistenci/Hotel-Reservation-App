using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Users.CreateUser
{
    public sealed record CreateUserCommand(
        string FirstName,
        string LastName,
        string UserName,
        string eMail,
        string Password,
        string PhoneNumber
        ) : IRequest<Result<string>>;
}
