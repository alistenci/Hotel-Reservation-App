using AutoMapper;
using eHotelApp.Application.Features.Auth.Users.UpdateUser;
using eHotelApp.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Users.UpdateUser
{
    public sealed record UpdateUserCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string UserName,
        string eMail,
        string Password,
        string PhoneNumber
        ) : IRequest<Result<string>>;
}

internal sealed class UpdateUserCommandHandler(
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        if(user is null)
        {
            return Result<string>.Failure("User not found");
        }

        if (await userManager.Users.AnyAsync(p => p.Email == request.eMail))
        {
            return Result<string>.Failure("Email already exists");
        }

        if (await userManager.Users.AnyAsync(p => p.UserName == request.UserName))
        {
            return Result<string>.Failure("Username already exists");
        }


        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        mapper.Map(request, user);

        if (!result.Succeeded)   // Kullanıcı oluşturma işlemi başarısızsa hata döndür
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return Result<string>.Failure($"User creation failed : {errors} ");
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);    // Değişiklikleri kaydet

        return "User update is successfull";

    }
}

