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
using DSEU.Application.Modules.Roles.Commands.CreateRole;
using DSEU.Application.Modules.Roles.Commands.RemoveRole;
using DSEU.Application.Modules.Roles.Commands.UpdateRole;
using DSEU.Application.Modules.Roles.Queries.GetAllRoles;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers.CoreEntities
{
    [Route("api/[controller]")]
    [SwaggerTag("Api для проведения операция с ролями")]
    [Authorize(Policy = GeneralPolicy.Admin)]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получить список ролей
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllRolesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        /// <summary>
        /// Добавить роль
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        // POST: api/Role/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateRoleCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }


        /// <summary>
        /// Обновить роль
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateRole([FromRoute]int id, [FromBody]UpdateRoleCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveRoleCommand(id));
            return NoContent();
        }
    }
}
