using DSEU.Application.Modules.Commons.TerritorialUnits.Comands.CreateTerritorialUnit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для добавлениий населенных пунктов")]
    public class TerritorialUnitController:ControllerBase
    {
        private readonly IMediator mediator;

        public TerritorialUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CreateTerritorialUnitComand createTerritorial) 
        {
            await mediator.Send(createTerritorial);
            return NoContent();
        }
    }
}
