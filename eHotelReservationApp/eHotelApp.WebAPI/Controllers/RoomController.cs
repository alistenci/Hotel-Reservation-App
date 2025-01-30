using eHotelApp.Application.Features.Auth.Users.GetAllUsers;
using eHotelApp.Application.Features.Rooms.Features.GetAllRoomFeatures;
using eHotelApp.Application.Features.Rooms.Features.RoomFeatures;
using eHotelApp.Application.Features.Rooms.Rooms.AddRooms;
using eHotelApp.Application.Features.Rooms.Rooms.GetAllRooms;
using eHotelApp.Application.Features.Rooms.Rooms.GetAllRoomsByFiltered;
using eHotelApp.Application.Features.Rooms.Types.GetAllTypes;
using eHotelApp.Application.Features.Rooms.Types.RoomTypes;
using eHotelApp.Application.Features.Rooms.Types.UpdateRoomTypes;
using eHotelApp.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHotelApp.WebAPI.Controllers
{
    [AllowAnonymous]
    public class RoomController : ApiController
    {
        public RoomController(IMediator mediatr) : base(mediatr)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomTypes(RoomTypesCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoomTypes(UpdateRoomTypesCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomFeature(RoomFeaturesCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(AddRoomsCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypes(CancellationToken cancellationToken)
        {
            //var response = await _mediatr.Send(request, cancellationToken);
            //return StatusCode(response.StatusCode, response);

            var request = new GetAllTypesQuery(); // İstek parametresi oluşturarak sorguyu gönder
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures(CancellationToken cancellationToken)
        {
            //var response = await _mediatr.Send(request, cancellationToken);
            //return StatusCode(response.StatusCode, response);

            var request = new GetAllRoomFeaturesQuery(); // İstek parametresi oluşturarak sorguyu gönder
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms(CancellationToken cancellationToken)
        {

            var request = new GetAllRoomsQuery(); // İstek parametresi oluşturarak sorguyu gönder
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllFilteredRooms(GetAllRoomsByFilteredQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
