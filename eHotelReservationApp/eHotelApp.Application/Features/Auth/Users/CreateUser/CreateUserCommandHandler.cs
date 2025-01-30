using AutoMapper;
using eHotelApp.Application.Features.Auth.Login;
using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler(UserManager<AppUser> userManager,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await userManager.Users.AnyAsync(p => p.Email == request.eMail))
            {
                return Result<string>.Failure("Email already exists");
            }
            if (await userManager.Users.AnyAsync(p => p.UserName == request.UserName))
            {
                return Result<string>.Failure("Username already exists");
            }

            var user = new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.eMail,
                PhoneNumber = request.PhoneNumber,
                Role = Roles.User,
            };

            IdentityResult result = await userManager.CreateAsync(user, request.Password);  // Kullanıcıyı oluştur

            if (!result.Succeeded)
            {
                return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());    // Kullanıcı oluşturulurken bir hata meydana gelirse, hata mesajları döner.
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "User create is successful";
        }
    }
}
