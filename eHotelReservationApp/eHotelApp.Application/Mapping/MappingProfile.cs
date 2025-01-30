using AutoMapper;
using eHotelApp.Application.Features.Reservations.AddReservations;
using eHotelApp.Application.Features.Rooms.Features.RoomFeatures;
using eHotelApp.Application.Features.Rooms.Rooms.AddRooms;
using eHotelApp.Application.Features.Rooms.Types.RoomTypes;
using eHotelApp.Application.Features.Rooms.Types.UpdateRoomTypes;
using eHotelApp.Domain.Entities;

namespace eHotelApp.Application.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<RoomFeatureCommand, RoomFeature>();

            //CreateMap<CreateUserCommand, AppUser>();

            CreateMap<RoomTypesCommand, RoomType>();
            CreateMap<RoomFeaturesCommand, RoomFeature>();
            CreateMap<AddRoomsCommand, HotelRooms>();

            CreateMap<UpdateRoomTypesCommand, RoomType>();

        }
    }
}
