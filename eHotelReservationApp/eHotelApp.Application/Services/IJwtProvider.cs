using eHotelApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHotelApp.Application.Services
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
