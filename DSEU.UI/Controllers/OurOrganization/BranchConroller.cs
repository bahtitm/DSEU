using DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.CreateBranch;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.DeleteBranch;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.UpdateBranch;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Queries.GetAllBranches;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Queries.GetBranchDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api For Branch")]
    public class BranchController : ControllerBase
    {
        private readonly IMediator mediator;

        public BranchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await mediator.Send(new GetAllBranchesQuery());
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetBranchDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBranchCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBranchCommand command)
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
            await mediator.Send(new DeleteBranchCommand(id));
            return NoContent();
        }
    }
}
