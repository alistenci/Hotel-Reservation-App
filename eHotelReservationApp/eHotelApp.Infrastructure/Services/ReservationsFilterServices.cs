using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using eHotelApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eHotelApp.Infrastructure.Services
{
    public sealed class ReservationsFilterServices( IHotelRoomsRepository hotelRoomsRepository, IReservationsRepository reservationsRepository) : IReservationsFilterServices
    {
        public async Task<List<HotelRooms>> ReservationsFilterAsync(int yetiskinSayisi, int cocukSayisi, DateTime startDate, DateTime endDate)
        {

            var suitableRooms = await hotelRoomsRepository.GetAll().Where(room => room.maxGuests >= yetiskinSayisi && room.maxChildren >= cocukSayisi).ToListAsync();

            var availableRooms = new List<HotelRooms>();

            foreach(var room in suitableRooms)
            {
                bool isRoomBooked = await reservationsRepository.GetAll()
                    .AnyAsync(reservation =>
                reservation.RoomId == room.Id &&
                (
                    (startDate < reservation.CheckOutDate && endDate > reservation.CheckInDate) ||
                    (startDate >= reservation.CheckInDate && startDate < reservation.CheckOutDate) ||
                    (endDate > reservation.CheckInDate && endDate <= reservation.CheckOutDate)
                ));

                if (!isRoomBooked)
                {
                    availableRooms.Add(room);
                }
            }

            // var uniqueRooms = availableRooms.GroupBy(room => room.RoomTypeId).Select(group => group.First()).ToList(); gruplama işlemi

            return availableRooms;
        }

    }
}
