using eHotelApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHotelApp.Application.Services
{
    public interface IReservationsFilterServices
    {
        Task<List<HotelRooms>> ReservationsFilterAsync(int yetiskinSayisi, int cocukSayisi, DateTime startDate, DateTime endDate);
    }
}
