using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.Company;
using DSEU.Application.Modules.Company.DepartmentMembers.Commands.AddDepartmentMember;
using DSEU.Application.Modules.Company.DepartmentMembers.Commands.RemoveDepartmentMember;
using DSEU.Application.Modules.Company.DepartmentMembers.Queries.GetAllDepartmentMembers;
using DSEU.Devexpress.Devexpress.Options;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Attributes;

namespace DSEU.UI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с составом подразделений")]
    public class DepartmentMembersController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentMembersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получает всех участников подразделения
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        // GET: api/DepartmentMembers/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<DepartmentMemberDto>), StatusCodes.Status200OK)]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.Read)]
        public async Task<IActionResult> Get([FromRoute]int id, DataSourceLoadOptions loadOptions)
        {
            var dataSource = await mediator.Send(new GetAllDepartmentMembersQuery(id));
            return Ok(await DataSourceLoader.LoadAsync(dataSource.AsQueryable(), loadOptions));
        }

        /// <summary>
        /// Добавить сотрудника к подразделению
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        // POST: api/DepartmentMembers/
        [HttpPost]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] AddDepartmentMemberCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Удалить сотрудника из подразделения
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        // DELETE: api/DepartmentMembers/5/6
        [HttpDelete("{departmentId}/{employeeId}")]
        [PermissionRequirement(EntityTypeGuid.Department, AccessRightsOperation.FullAccess)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete([FromRoute]int departmentId, [FromRoute]int employeeId)
        {
            await mediator.Send(new RemoveDepartmentMemberCommand(departmentId, employeeId));
            return NoContent();
        }
    }
}
