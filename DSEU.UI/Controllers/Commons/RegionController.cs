using DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion;
using DSEU.Application.Modules.Commons.Regions.Commands.DeleteRegion;
using DSEU.Application.Modules.Commons.Regions.Commands.UpdateRegion;
using DSEU.Application.Modules.Commons.Regions.Queries.GetAllRegions;
using DSEU.Application.Modules.Commons.Regions.Queries.GetRegionDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для региона")]
    public class RegionController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllRegionsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {
            return Ok(await mediator.Send(new GetRegionDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRegionCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRegionCommand command)
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
            await mediator.Send(new DeleteRegionCommand(id));
            return NoContent();
        }
    }
}
