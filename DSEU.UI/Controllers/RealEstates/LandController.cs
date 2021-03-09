using DSEU.Application.Modules.RealEstates.Lands.Commands.CreateLand;
using DSEU.Application.Modules.RealEstates.Lands.Commands.DeleteLand;
using DSEU.Application.Modules.RealEstates.Lands.Commands.UpdateLand;
using DSEU.Application.Modules.RealEstates.Lands.Queries.GetAllLands;
using DSEU.Application.Modules.RealEstates.Lands.Queries.GetLandDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.RealEstates
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для земельные участки")]
    public class LandController : ControllerBase
    {
        private readonly IMediator mediator;

        public LandController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllLandsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            return Ok(await mediator.Send(new GetLandDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLandCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLandCommand command)
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
            await mediator.Send(new DeleteLandCommand(id));
            return NoContent();
        }
    }
}
