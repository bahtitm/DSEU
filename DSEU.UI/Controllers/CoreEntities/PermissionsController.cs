using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos;
using DSEU.Application.Modules.Permissions.Commands;
using DSEU.Application.Modules.Permissions.Queries.GetRecipientPermissions;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers.AccssRights
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с разрешениями на субъекты прав в системе")]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PermissionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Permissions/{recipientId}
        [HttpGet("{recipientId}")]
        [ProducesResponseType(typeof(IEnumerable<RecipientPermissionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetRecipientPermissions([FromRoute]int recipientId, DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetRecipientPermissionsQuery(recipientId));
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // POST: api/Permissions
        [HttpPost]
        [Authorize(GeneralPolicy.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateRecipientPermissionCommand command)
        {
            await mediator.Send(command);
            return Ok();

        }

        // PUT: api/Permissions
        [HttpPut]
        [Authorize(GeneralPolicy.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put([FromBody] UpdateRecipientPermissionCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{id}")]
        [Authorize(GeneralPolicy.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteRecipientPermissionCommand(id));
            return NoContent();
        }
    }
}
