using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Login
{
    internal sealed class LoginCommandHandler(UserManager<AppUser> userManager,
        IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p =>
            p.UserName == request.usernameOrEmail || 
            p.Email == request.usernameOrEmail, cancellationToken);

            if (appUser is null)
            {
                return Result<LoginCommandResponse>.Failure("User Not Found");
            }
            bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.password);
            if (!isPasswordCorrect)
              {
                  return Result<LoginCommandResponse>.Failure("Password is wrong");
              }

            // Token ekle
            string token = await jwtProvider.CreateTokenAsync(appUser);
            return Result<LoginCommandResponse>.Succeed(new LoginCommandResponse(token));
            
        }
    }
}
