using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Application.Modules.RoleMembers.Commands.AddRoleMember;
using DSEU.Application.Modules.RoleMembers.Commands.RemoveRoleMember;
using DSEU.Application.Modules.RoleMembers.Queries.GetAllRoleMembers;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers.CoreEntities
{
    [Route("api/[controller]")]
    [Authorize(Policy = GeneralPolicy.Admin)]
    [ApiController]
    [SwaggerTag("Api для проведения операция с участниками ролей")]
    public class RoleMembersController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoleMembersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получает всех участников роли
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        // GET: api/RoleMembers/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<RoleMemberDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([FromRoute]int id, DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllRoleMembersQuery(id));
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        /// <summary>
        /// Добавить участника к роли
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        // POST: api/RoleMembers/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] AddRoleMemberCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удалить участника из роли
        /// </summary>
        /// <param name="roleId">ID роли</param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        // DELETE: api/RoleMembers/5/6
        [HttpDelete("{roleId}/{memberId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete([FromRoute]int roleId, [FromRoute]int memberId)
        {
            await mediator.Send(new RemoveRoleMemberCommand(roleId, memberId));
            return NoContent();
        }
    }
}
