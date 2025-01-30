using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Context;
using GenericRepository;

namespace eHotelApp.Infrastructure.Repositories
{
    internal sealed class RoomTypesRepository : Repository<RoomType, ApplicationDbContext>, IRoomTypeRepository
    {
        public RoomTypesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
