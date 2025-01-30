using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Email.SendCode
{
    public sealed record SendCodeResponse(string email) : IRequest<Result<string>>;
}
