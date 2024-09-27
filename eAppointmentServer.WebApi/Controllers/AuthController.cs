using eAppointmentServer.Application.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthController (IMediator _mediator): ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
