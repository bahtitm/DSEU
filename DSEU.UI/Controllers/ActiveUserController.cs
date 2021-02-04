using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSEU.Application.Dtos;
using DSEU.Application.Modules.ActiveUsers.Commands.EndSessions;
using DSEU.Application.Modules.ActiveUsers.Queries.GetAllActiveUsers;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Api для работы с активными пользователями")]
    [Authorize(Policy = GeneralPolicy.Admin)]
    [ApiController]
    public class ActiveUserController : ControllerBase
    {
        private readonly IMediator mediator;

        public ActiveUserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получить всех активных пользователей
        /// </summary>
        /// <returns></returns>
        /// GET: api/ActiveUser
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ActiveUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllActiveUsersQuery());
            return Ok(result);
        }

        /// <summary>
        /// Завершить сеанс пользователя
        /// </summary>
        /// <returns></returns>
        /// POST: api/ActiveUser/EndSession
        [HttpPost("EndSession")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] EndSessionCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

    }
}