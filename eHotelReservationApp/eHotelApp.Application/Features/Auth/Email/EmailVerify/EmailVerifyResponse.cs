using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Email.EmailVerify
{
    public sealed record EmailVerifyResponse(string verifyCode, string email) : IRequest<Result<string>>;
}