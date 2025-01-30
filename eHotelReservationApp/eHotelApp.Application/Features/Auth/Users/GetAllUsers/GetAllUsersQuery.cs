using eHotelApp.Domain.Entities;
using MediatR;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Users.GetAllUsers
{
    public sealed record GetAllUsersQuery() : IRequest<Result<List<AppUser>>>;
}
