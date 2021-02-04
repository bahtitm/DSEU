using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Company;
using DSEU.Application.MappingProfiles;
using DSEU.Application.Modules.Company.Employees.Commands.ChangePassword;
using DSEU.Application.Modules.Company.Employees.Commands.EditEmployee;
using DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee;
using DSEU.Application.Modules.Company.Employees.Queries.GetAllEmployees;
using DSEU.Application.Modules.Company.Employees.Queries.GetEmployeeDetail;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с сотрудниками (пользователями) организации")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Employee
        [HttpGet]
        [PermissionRequirement(EntityTypeGuid.Employee, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllEmployeesQuery());
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        // GET: api/Employee
        [HttpGet("{id}")]
        [PermissionRequirement(EntityTypeGuid.Employee, AccessRightsOperation.Read)]
        [ProducesResponseType(typeof(EmployeeDetailDto), 200)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetDetail([FromRoute]int id)
        {
            return Ok(await mediator.Send(new GetEmployeeDetailQuery(id)));
        }

        /// <summary>
        /// Регистрация сотрудника
        /// </summary>
        /// <param name="command"></param>
        /// <returns>ID сотрудника</returns>
        // POST: api/Employee
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Employee, AccessRightsOperation.Create)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromForm] RegisterEmployeeCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        // POST: api/Employee
        [HttpPost("ChangePassword")]
        [PermissionRequirement(EntityTypeGuid.Employee, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [PermissionRequirement(EntityTypeGuid.Employee, AccessRightsOperation.Edit)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int id, [FromForm] EditEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Invalid id");
            }

            await mediator.Send(command);
            return NoContent();
        }
    }
}
