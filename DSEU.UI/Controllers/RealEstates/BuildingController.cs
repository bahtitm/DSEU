using DSEU.Application.Modules.RealEstates.Buildings.Commands.CreateBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Commands.DeleteBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Commands.UpdateBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Queries.GetAllBuildings;
using DSEU.Application.Modules.RealEstates.Buildings.Queries.GetBuildingDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthorizationService authorizationService;

        public BuildingController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
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


        //[Authorize(Policy = AuthPolicy.RegisterRealEstate)]
        //public async Task<IActionResult> Register([FromBody] object command)
        //{
        //    var result = await authorizationService.AuthorizeAsync(User, command, AuthPolicy.RegisterRealEstate);
        //    if (!result.Succeeded)
        //        return Forbid();

        //}

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
