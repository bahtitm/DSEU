using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.CreateContact;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.EditContact;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.RemoveContact;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Models;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Queries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Parties
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операций с контактами (контрагенты)")]
    public class ContactController : Controller
    {
        private readonly IMediator mediator;
        public ContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //GET: api/Contact
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Contact, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<ContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllContactsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // GET: api/Contact/1
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.Contact, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await mediator.Send(new GetContactByIdQuery(id)));
        }


        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Contact, AccessRightsOperation.Create)]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand command)
        {
            var entity = await mediator.Send(command);
            return Ok(entity);
        }

        //PUT: api/Contact/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Contact, AccessRightsOperation.Edit)]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            var entity = await mediator.Send(command);
            return Ok(entity);

        }

        //DELETE: api/Contact/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Contact, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveContactCommand(id));
            return NoContent();
        }
    }
}
