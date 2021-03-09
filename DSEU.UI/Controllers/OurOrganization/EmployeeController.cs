using DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с сотрудниками (пользователями) организации")]
    public class EmployeeController:ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        
        public async Task<IActionResult> Post([FromForm] CreateEmployeeCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }
    }
}
