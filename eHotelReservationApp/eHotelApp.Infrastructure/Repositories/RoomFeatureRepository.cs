using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Context;
using GenericRepository;

namespace eHotelApp.Infrastructure.Repositories
{
    internal sealed class RoomFeatureRepository : Repository<RoomFeature, ApplicationDbContext>, IRoomFeatureRepository
    {
        public RoomFeatureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
