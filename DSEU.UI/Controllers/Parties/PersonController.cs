using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Modules.Parties.Persons.Commands.CreatePerson;
using DSEU.Application.Modules.Parties.Persons.Commands.EditPerson;
using DSEU.Application.Modules.Parties.Persons.Commands.RemovePerson;
using DSEU.Application.Modules.Parties.Persons.Models;
using DSEU.Application.Modules.Parties.Persons.Queries;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Parties
{
    /// <summary>
    /// Физические лица
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с физическими лицами (контрагенты)")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Person
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), StatusCodes.Status200OK)]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllPersonsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // GET: api/Person/1
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await mediator.Send(new GetPersonByIdQuery(id)));
        }

        // POST: api/Person
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Create)]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand command)
        {
            var entity = await mediator.Send(command);
            return Ok(entity);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.Edit)]
        [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditPersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            var entity = await mediator.Send(command);
            return Ok(entity);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Counterparty, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemovePersonCommand { Id = id });
            return NoContent();
        }
    }
}
