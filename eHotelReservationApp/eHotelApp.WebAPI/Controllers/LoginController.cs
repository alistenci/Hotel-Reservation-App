using eHotelApp.Application.Features.Auth.Login;
using eHotelApp.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHotelApp.WebAPI.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        public LoginController(IMediator mediatr) : base(mediatr)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
