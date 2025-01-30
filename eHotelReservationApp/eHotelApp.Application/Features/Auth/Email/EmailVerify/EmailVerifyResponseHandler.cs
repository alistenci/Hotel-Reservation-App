using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Email.EmailVerify
{
    internal sealed class EmailVerifyResponseHandler(
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork
) : IRequestHandler<EmailVerifyResponse, Result<string>>
    {
        public async Task<Result<string>> Handle(EmailVerifyResponse request, CancellationToken cancellationToken)
        {
            // Kullanıcıyı bulma
            AppUser? user = await userManager.FindByEmailAsync(request.email);
            if (user is null)
            {
                return Result<string>.Failure("User not found");
            }

            // Email onaylanmadıysa ve email mevcutsa
            if (user.EmailConfirmed == false && user.Email != null)
            {
                // Kod süresi dolmuşsa
                if (user.VerificationExpiry < DateTime.UtcNow)
                {
                    user.VerificationCode = null;
                    await userManager.UpdateAsync(user);
                    return Result<string>.Failure("Kodun süresi dolmuş, yeni kod gönder");
                }
                else
                {
                    // Kod geçerliyse
                    if (user.VerificationCode == request.verifyCode)
                    {
                        //await emailSender.SendEmailAsync(user.Email, "Kayıt Başarılı", "Kayıt Oldunuz...");
                        user.EmailConfirmed = true;
                        user.VerificationCode = null;
                        await userManager.UpdateAsync(user); // Değişiklikleri kaydet
                        return Result<string>.Succeed("Başarılı Kod");
                    }
                    else
                    {
                        return Result<string>.Failure("Hatalı kod");
                    }
                }
            }
            else if (user.EmailConfirmed == true)
            {
                return Result<string>.Failure("E-Posta doğrulaması zaten yapılmış");
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<string>.Succeed("Başarılı");
        }
    }
}
