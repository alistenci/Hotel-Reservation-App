using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Context;
using GenericRepository;

namespace eHotelApp.Infrastructure.Repositories
{
    internal sealed class ReservationsRepository : Repository<Reservations, ApplicationDbContext>, IReservationsRepository
    {
        public ReservationsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
