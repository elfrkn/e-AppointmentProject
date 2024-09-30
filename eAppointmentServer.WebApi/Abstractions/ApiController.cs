using MediatR;
using Microsoft.AspNetCore.Mvc;



//Bu class artık api controllerda inherit edilen base class haline geldi.
namespace eAppointmentServer.WebApi.Abstractions
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    //abstarct:Tek başına newlenemesin ve kullanılamasın.Mutlaka inherit edilmesi gereksin
    public abstract class ApiController : ControllerBase
    {
        public readonly IMediator _mediator;

        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
