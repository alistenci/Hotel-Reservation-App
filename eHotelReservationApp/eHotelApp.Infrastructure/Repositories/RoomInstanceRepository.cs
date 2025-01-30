using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Context;
using GenericRepository;

namespace eHotelApp.Infrastructure.Repositories
{
    internal sealed class RoomInstanceRepository : Repository<RoomInstance, ApplicationDbContext>, IRoomInstanceRepository
    {
        public RoomInstanceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
