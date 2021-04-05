using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.CreateOrganizationalUnit;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.DeleteOrganizationalUnit;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.UpdateOrganizationalUnit;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Queries.GetAllOrganizationalUnits;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Queries.GetOrganizationalUnitDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для населеного пункта")]
    public class OrganizationalUnitController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrganizationalUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllOrganizationalUnitsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await mediator.Send(new GetOrganizationalUnitDetailQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrganizationalUnitCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOrganizationalUnitCommand command)
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
            await mediator.Send(new DeleteOrganizationalUnitCommand(id));
            return NoContent();
        }
    }
}
