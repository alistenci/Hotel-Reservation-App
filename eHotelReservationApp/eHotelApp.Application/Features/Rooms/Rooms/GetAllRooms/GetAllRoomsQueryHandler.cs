using eHotelApp.Application.Features.Rooms.Rooms.GetAllRooms;
using eHotelApp.Application.Services;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class GetAllRoomsQueryHandler(IHotelRoomsRepository hotelRoomsRepository) : IRequestHandler<GetAllRoomsQuery, Result<List<HotelRooms>>>
{
    public async Task<Result<List<HotelRooms>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        List<HotelRooms> hotelRooms = await hotelRoomsRepository.GetAll().OrderBy(p => p.roomNumber).ToListAsync(cancellationToken);
        return hotelRooms;
    }
}
