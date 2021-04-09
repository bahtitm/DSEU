using DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.CreateDepartament;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.DeleteDepartament;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.UpdateDepartament;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Queries.GetAllDepartaments;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Queries.GetDepartamentDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api For Departament")]
    public class DepartamentController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartamentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await mediator.Send(new GetAllDepartamentsQuery());
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDepartamentDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDepartamentCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDepartamentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteDepartamentCommand(id));
            return NoContent();
        }
    }
}