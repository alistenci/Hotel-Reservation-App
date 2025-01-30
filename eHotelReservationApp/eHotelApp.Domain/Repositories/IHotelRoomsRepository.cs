using eHotelApp.Domain.Entities;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace eHotelApp.Domain.Repositories
{
    public interface IHotelRoomsRepository : IRepository<HotelRooms>
    {
        
    }
}
