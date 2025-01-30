using AutoMapper;
using eHotelApp.Application.Features.Rooms.Types.UpdateRoomTypes;
using eHotelApp.Domain.Entities;
using eHotelApp.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eHotelApp.Application.Features.Rooms.Types.UpdateRoomTypes
{
    public sealed record UpdateRoomTypesCommand(Guid Id, string TypeName, decimal Price, string ImageURL) : IRequest<Result<string>>;
}

public sealed class UpdateRoomTypesCommandHandler(IHotelRoomsRepository hotelRoomsRepository , IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateRoomTypesCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateRoomTypesCommand request, CancellationToken cancellationToken)
    {
        RoomType? roomType = await roomTypeRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if(roomType == null)
        {
            return Result<string>.Failure("Room types is not found");
        }

        mapper.Map(request, roomType);
        roomTypeRepository.Update(roomType);

        var relatedRooms = await hotelRoomsRepository.GetAll().Where(r => r.RoomTypeId == roomType.Id).ToListAsync(cancellationToken);

        foreach(var room in relatedRooms)
        {
            room.RoomType = roomType.TypeName;
            room.price = roomType.Price;
            hotelRoomsRepository.Update(room);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Successful";
    }
}
