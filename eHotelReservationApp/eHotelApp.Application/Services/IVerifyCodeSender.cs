using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHotelApp.Application.Services
{
    public interface IVerifyCodeSender
    {
        Task SendCodeAsync(string email);
    }
}
