using DSEU.Application.Modules.Company.OurOrganization.Commands.CreateUser;
using DSEU.Application.Modules.Company.OurOrganization.Commands.DeleteUser;
using DSEU.Application.Modules.Company.OurOrganization.Commands.UpdateUser;
using DSEU.Application.Modules.Company.OurOrganization.Queries.GetAllUser;
using DSEU.Application.Modules.Company.OurOrganization.Queries.GetUserDetail;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateUserCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteUserComand(id));
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await mediator.Send(new GetAllUserQuery());
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await mediator.Send(new GetUserDetailQuery(id)));
        }
    }
}