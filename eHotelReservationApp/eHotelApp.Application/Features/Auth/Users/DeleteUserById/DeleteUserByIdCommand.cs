﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eHotelApp.Application.Features.Auth.Users.DeleteUserById
{
    public sealed record DeleteUserByIdCommand(Guid Id) : IRequest<Result<string>>;
}
