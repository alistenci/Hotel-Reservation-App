using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eHotelApp.Infrastructure.Services
{
    public sealed class VerifyCodeSender(IEmailSender emailSender, UserManager<AppUser> userManager) : IVerifyCodeSender
    {
        public async Task SendCodeAsync(string email)
        {
            AppUser? user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

           
                Random random = new Random();
                string verificationCode = random.Next(100000, 999999).ToString();
                user.VerificationCode = verificationCode;
                await emailSender.SendEmailAsync(user.Email, "b", $"{verificationCode}");
                user.VerificationExpiry = DateTime.UtcNow.AddSeconds(120).ToUniversalTime();
                await userManager?.UpdateAsync(user);
            

        }
    }
}
