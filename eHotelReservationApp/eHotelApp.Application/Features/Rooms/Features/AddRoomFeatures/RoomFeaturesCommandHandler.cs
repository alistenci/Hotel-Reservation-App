using AutoMapper;
using eHotelApp.Application.Features.Rooms.Features.RoomFeatures;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

internal sealed class RoomFeaturesCommandHandler(IRoomFeatureRepository roomFeatureRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<RoomFeaturesCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RoomFeaturesCommand request, CancellationToken cancellationToken)
    {
        if(await roomFeatureRepository.AnyAsync(p => p.FeatureName == request.FeatureName))
        {
            return Result<string>.Failure("This feature name already exists");
        }

        RoomFeature roomFeature = mapper.Map<RoomFeature>(request);
       
        await roomFeatureRepository.AddAsync(roomFeature, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Room feature added is successful";
    }
}
