using AutoMapper;
using eHotelApp.Application.Features.Rooms.Types.RoomTypes;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

internal sealed class RoomTypesCommandHandler(IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<RoomTypesCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RoomTypesCommand request, CancellationToken cancellationToken)
    {
        // RoomType roomType = await roomTypeRepository.GetByExpressionWithTrackingAsync(p => p.TypeName == request.TypeName, cancellationToken);

        if(await roomTypeRepository.AnyAsync(p => p.TypeName == request.TypeName))
        {
            return Result<string>.Failure("This room type name already exists");
        }

        RoomType roomType = mapper.Map<RoomType>(request);
        roomType.ImageUrl = request.ImageURL;

        await roomTypeRepository.AddAsync(roomType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Room Type add is successful";
    }
}
