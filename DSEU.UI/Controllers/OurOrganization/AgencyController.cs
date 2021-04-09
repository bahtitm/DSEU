using DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.CreateAgency;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.DeleteAgency;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.UpdateAgency;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Queries.GetAgencyDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api For Agency")]
    public class AgencyController : ControllerBase
    {
        private readonly IMediator mediator;

        public AgencyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await mediator.Send(new GetAllAgenciesQuery());
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetAgencyDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAgencyCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAgencyCommand command)
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
            await mediator.Send(new DeleteAgencyCommand(id));
            return NoContent();
        }
    }
}
