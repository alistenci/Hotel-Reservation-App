using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Context;
using GenericRepository;

namespace eHotelApp.Infrastructure.Repositories
{
    internal sealed class HotelRoomsRepository : Repository<HotelRooms, ApplicationDbContext>, IHotelRoomsRepository
    {
        public HotelRoomsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
