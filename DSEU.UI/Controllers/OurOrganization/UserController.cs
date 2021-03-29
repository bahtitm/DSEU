using DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.CreateUser;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.DeleteUser;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.UpdateUser;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Queries.GetAllUser;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Queries.GetUserDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers.OurOrganization
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с сотрудниками (пользователями) организации")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await mediator.Send(new GetAllUserQuery());
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetUserDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserComand command)
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
            await mediator.Send(new DeleteUserComand(id));
            return NoContent();
        }                
    }
}