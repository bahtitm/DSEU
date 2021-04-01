using DSEU.Application.Modules.Company.OurOrganization.Role.Commands.CreateRole;
using DSEU.Application.Modules.Company.OurOrganization.Role.Commands.DeleteRole;
using DSEU.Application.Modules.Company.OurOrganization.Role.Commands.UpdateRole;
using DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetAllRoles;
using DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetRoleDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для ролей")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await mediator.Send(new GetAllRolesQuery());
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await mediator.Send(new GetRoleDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await mediator.Send(new DeleteRoleCommand(id));
            return NoContent();
        }
    }
}
