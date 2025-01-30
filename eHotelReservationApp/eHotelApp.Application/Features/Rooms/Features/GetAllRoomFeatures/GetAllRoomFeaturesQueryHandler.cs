using eHotelApp.Application.Features.Rooms.Features.GetAllRoomFeatures;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class GetAllRoomFeaturesQueryHandler(IRoomFeatureRepository roomFeatureRepository) : IRequestHandler<GetAllRoomFeaturesQuery, Result<List<RoomFeature>>>
{
    public async Task<Result<List<RoomFeature>>> Handle(GetAllRoomFeaturesQuery request, CancellationToken cancellationToken)
    {
        List<RoomFeature> roomFeature = await roomFeatureRepository.GetAll().OrderBy(p => p.Id).ToListAsync(cancellationToken);
        return roomFeature;
    }
}
