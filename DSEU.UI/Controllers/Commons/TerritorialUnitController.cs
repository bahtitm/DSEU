using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.CreateTerritorialUnit;
using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.DeleteTerritorialUnit;
using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.UpdateTerritorialUnit;
using DSEU.Application.Modules.Commons.TerritorialUnits.Queries.GetAll;
using DSEU.Application.Modules.Commons.TerritorialUnits.Queries.GetDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для добавлениий населенных пунктов")]
    public class TerritorialUnitController : ControllerBase
    {
        private readonly IMediator mediator;

        public TerritorialUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var terrUnit = await mediator.Send(new GetAllTerritorialUnitQuery());
            return Ok(terrUnit);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailTerritorialUnitQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateTerritorialUnitComand createTerritorial)
        {
            await mediator.Send(createTerritorial);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateTerritorialUnitCommand command)
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
            await mediator.Send(new DeleteTerritorialUnitComand(id));
            return NoContent();
        }
    }
}
