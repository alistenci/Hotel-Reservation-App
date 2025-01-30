using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Context;
using GenericRepository;

namespace eHotelApp.Infrastructure.Repositories
{
    internal sealed class GuestsRepository : Repository<Guests, ApplicationDbContext>, IGuestsRepository
    {
        public GuestsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
