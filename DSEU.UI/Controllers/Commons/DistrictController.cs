using DSEU.Application.Modules.Commons.Districts.Commands.CreateDistrict;
using DSEU.Application.Modules.Commons.Districts.Commands.DeleteDistrict;
using DSEU.Application.Modules.Commons.Districts.Commands.UpdateDistrict;
using DSEU.Application.Modules.Commons.Districts.Queries.GetAllDistricts;
using DSEU.Application.Modules.Commons.Districts.Queries.GetDistrictDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/{controller}")]
    [ApiController]
    [SwaggerTag("Api для района")]
    public class DistrictController : ControllerBase
    {
        private readonly IMediator mediator;

        public DistrictController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllDistrictsQuery());
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {
            return Ok(await mediator.Send(new GetDistrictDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDistrictCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDistrictCommand command)
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
            await mediator.Send(new DeleteDistrictCommand(id));
            return NoContent();
        }
    }
}
