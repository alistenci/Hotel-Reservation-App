using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Email.SendCode
{
    internal sealed class SendCodeHandler(IVerifyCodeSender codeSender, UserManager<AppUser> userManager) : IRequestHandler<SendCodeResponse, Result<string>>
    {
        public async Task<Result<string>> Handle(SendCodeResponse request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByEmailAsync(request.email);

            if (user is null)
            {
                return Result<string>.Failure("User not found");
            }
            if(user.Email != null && user.EmailConfirmed != true)
            {
                await codeSender.SendCodeAsync(user.Email);
                return "Kod gönderme başarılı";
            }
            else
            {
                return "Doğrulama işlemi yapılmış";
            }
            
        }
    }
}
