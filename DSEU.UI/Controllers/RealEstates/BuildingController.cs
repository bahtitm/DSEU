using DSEU.Application.Modules.RealEstates.Buildings.Commands.CreateBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Commands.DeleteBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Commands.UpdateBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Queries.GetAllBuildings;
using DSEU.Application.Modules.RealEstates.Buildings.Queries.GetBuildingDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.RealEstates
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для строительство")]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator mediator;

        public BuildingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllBuildingsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            return Ok(await mediator.Send(new GetBuildingDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBuildingCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBuildingCommand command)
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
            await mediator.Send(new DeleteBuildingCommand(id));
            return NoContent();
        }
    }
}
