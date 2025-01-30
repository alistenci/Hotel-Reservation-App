using eHotelApp.Application.Features.Rooms.Types.GetAllTypes;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class GetAllTypesQueryHandler(IRoomTypeRepository roomTypeRepository) : IRequestHandler<GetAllTypesQuery, Result<List<RoomType>>>
{
    public async Task<Result<List<RoomType>>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        List<RoomType> roomTypes = await roomTypeRepository.GetAll().OrderBy(p => p.Id).ToListAsync(cancellationToken);
        return roomTypes;
    }
}
