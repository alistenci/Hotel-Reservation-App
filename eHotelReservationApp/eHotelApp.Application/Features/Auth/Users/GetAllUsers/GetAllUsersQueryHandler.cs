using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Users.GetAllUsers
{
    internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, Result<List<AppUser>>>
    {
        public async Task<Result<List<AppUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
           List<AppUser> users = await userRepository.GetAll().AsNoTracking().OrderBy(p => p.FirstName).ToListAsync(cancellationToken);
            return users;
        }
    }
}
