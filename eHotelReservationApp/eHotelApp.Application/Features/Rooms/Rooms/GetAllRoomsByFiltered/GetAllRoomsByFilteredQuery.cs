using eHotelApp.Application.Features.Rooms.Rooms.GetAllRoomsByFiltered;
using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Rooms.GetAllRoomsByFiltered
{
    public sealed record GetAllRoomsByFilteredQuery(int yetiskinSayisi, int cocukSayisi, DateTime startDate, DateTime endDate) : IRequest<Result<List<HotelRooms>>>;
}

internal sealed class GetAllRoomsByFilteredQueryHandler(IReservationsFilterServices reservationsFilterServices) : IRequestHandler<GetAllRoomsByFilteredQuery, Result<List<HotelRooms>>>
{
    public async Task<Result<List<HotelRooms>>> Handle(GetAllRoomsByFilteredQuery request, CancellationToken cancellationToken)
    {
        List<HotelRooms> filteredRooms = await reservationsFilterServices.ReservationsFilterAsync(request.yetiskinSayisi, request.cocukSayisi, request.startDate, request.endDate);

        if (!filteredRooms.Any())
        {
            return Result<List<HotelRooms>>.Failure("Uygun oda bulunamadı");
        }
        return Result<List<HotelRooms>>.Succeed(filteredRooms);
    }
}
