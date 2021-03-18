using DSEU.Application.Modules.Statements.Commands.RegisterStatement;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace DSEU.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для решестрации заявлений")]
    public class RegisterStatementController: ControllerBase
    {
        private readonly IMediator mediator;

        public RegisterStatementController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegistrerStatment([FromForm]RegisterStatementCommand registerStatementCommand) 
        {
            await mediator.Send(registerStatementCommand);
            return NoContent();            
        }
    }
}
