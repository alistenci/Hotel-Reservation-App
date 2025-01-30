using eHotelApp.Application.Features.Auth.Email.EmailVerify;
using eHotelApp.Application.Features.Auth.Email.SendCode;
using eHotelApp.Application.Features.Auth.Users.CreateUser;
using eHotelApp.Application.Features.Auth.Users.DeleteUserById;
using eHotelApp.Application.Features.Auth.Users.GetAllUsers;
using eHotelApp.Application.Features.Auth.Users.UpdateUser;
using eHotelApp.Application.Services;
using eHotelApp.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHotelApp.WebAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly IVerifyCodeSender verifyCodeSender;
        public AuthController(IMediator mediatr, IVerifyCodeSender verifyCodeSender) : base(mediatr)
        {
            this.verifyCodeSender = verifyCodeSender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(/*GetAllUsersQuery request, */CancellationToken cancellationToken)
        {
            //var response = await _mediatr.Send(request, cancellationToken);
            //return StatusCode(response.StatusCode, response);

            var request = new GetAllUsersQuery(); // İstek parametresi oluşturarak sorguyu gönderin.
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyCode(EmailVerifyResponse request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> SendCode(SendCodeResponse request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


    }
}
