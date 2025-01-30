using eHotelApp.Application.Features.Auth.Login;
using eHotelApp.Application.Features.Reservations.AddReservations;
using eHotelApp.Application.Features.Reservations.GetReservationsInfoById;
using eHotelApp.Application.Features.Rooms.Types.GetAllTypes;
using eHotelApp.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHotelApp.WebAPI.Controllers
{
    [AllowAnonymous]

    public class ReservationsController : ApiController
    {
        public ReservationsController(IMediator mediatr) : base(mediatr)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddReservations(AddReservationsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationsDate([FromQuery] Guid roomId , CancellationToken cancellationToken)
        {
            var request = new GetReservationsInfoByIdCommand(roomId); // İstek parametresi oluşturarak sorguyu gönder
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        //[HttpPost]
        //public async Task<IActionResult> GetAllReservationsDate(GetReservationsInfoByIdCommand request, CancellationToken cancellationToken)
        //{
        //    var response = await _mediatr.Send(request, cancellationToken);
        //    return StatusCode(response.StatusCode, response);
        //}
    }
}
