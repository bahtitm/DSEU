using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Company;
using DSEU.Application.Modules.Company.Departments.Commands.CreateDepartment;
using DSEU.Application.Modules.Company.Departments.Commands.EditDepartment;
using DSEU.Application.Modules.Company.Departments.Commands.RemoveDepartment;
using DSEU.Application.Modules.Company.Departments.Queries.GetAllDepartments;
using DSEU.Application.Modules.Company.Departments.Queries.GetDepartmentsById;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с подразделениями организации")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получает все подразделения
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        // GET: api/Department
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllDepartmentsQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }


        // GET: api/Department/id
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetById(int id)
        {
            var dataSource = await mediator.Send(new GetDepartmentsByIdQuery(id));
            return Ok(dataSource);
        }



        // POST: api/Department
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromBody] EditDepartmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }

            await mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveDepartmentCommand { Id = id });
            return NoContent();
        }
    }
}
