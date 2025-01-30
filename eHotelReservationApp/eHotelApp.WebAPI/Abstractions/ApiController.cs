using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHotelApp.WebAPI.Abstractions
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public abstract class ApiController : ControllerBase
    {
        public readonly IMediator _mediatr;

        protected ApiController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
    }
}
