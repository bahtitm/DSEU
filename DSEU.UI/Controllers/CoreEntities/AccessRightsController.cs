using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DSEU.Application.Dtos.AccessRights;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities;
using DSEU.Security.AccessRights;
using DSEU.Security.Policies;

namespace DSEU.UI.Controllers.AccssRights
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api для проведения операция с правами доступа")]
    public class AccessRightsController : ControllerBase
    {
        private readonly IAccessRightsService accessRightsService;
        private readonly IAuthorizationService authorizationService;

        public AccessRightsController(IAccessRightsService accessRightsService, IAuthorizationService authorizationService)
        {
            this.accessRightsService = accessRightsService;
            this.authorizationService = authorizationService;
        }

        // GET: api/AccessRights/1
        /// <summary>
        /// Получить список прав доступа
        /// </summary>
        /// <param name="entityId">ID сущности</param>
        /// <returns></returns>
        [HttpGet("{entityTypeGuid}/{entityId}")]
        [ProducesResponseType(typeof(IEnumerable<AccessRightDto>), 200)]
        public async Task<IActionResult> GetAccessRights([FromRoute] EntityTypeGuid entityTypeGuid, [FromRoute] int entityId)
        {
            var permissionRequest = new ReadAccessRightsPermissionRequest(entityId, entityTypeGuid);
            var authResult = await authorizationService.AuthorizeAsync(User, permissionRequest, AccessRightPolicy.Read);
            if (!authResult.Succeeded)
                return Forbid();

            return Ok(await accessRightsService.GetAccessRight(new AccessRightEntity(entityId, entityTypeGuid)));
        }

        /// <summary>
        /// Выдать права доступа
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/AccessRightss
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post([FromBody] GrantAccessRightDto dto)
        {
            var permissionRequest = new GrantAccessRightsPermissionRequest(dto.RecipientId, dto.EntityId, dto.AccessRightTypeId, dto.EntityType);
            var authResult = await authorizationService.AuthorizeAsync(User, permissionRequest, AccessRightPolicy.Grant);
            if (!authResult.Succeeded)
                return Forbid();

            await accessRightsService.GrantAccessRight(new AccessRightEntity(dto.EntityId, dto.EntityType), dto.RecipientId, dto.AccessRightTypeId);

            return NoContent();
        }

        /// <summary>
        /// Обновить права доступа
        /// </summary>
        /// <param name="accessRightEntryId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT: api/AccessRightss/5
        [HttpPut("{accessRightEntryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Put(int accessRightEntryId, [FromBody] UpdateAccessRightDto model)
        {
            if (accessRightEntryId != model.AccessRightEntryId)
                return BadRequest();

            var permissionRequest = new UpdateAccessRightsPermissionRequest(model.AccessRightEntryId, model.AccessRightTypeId);
            var authResult = await authorizationService.AuthorizeAsync(User, permissionRequest, AccessRightPolicy.Update);
            if (!authResult.Succeeded)
                return Forbid();

            await accessRightsService.UpdateAccessRight(model.AccessRightEntryId, model.AccessRightTypeId);

            return NoContent();
        }

        /// <summary>
        /// Отозвать(Удалить) права досутпа
        /// </summary>
        /// <param name="accessRightEntryId">Запись прав доступа</param>
        /// <returns></returns>
        // DELETE: api/AccessRightss/5
        [HttpDelete("{accessRightEntryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int accessRightEntryId)
        {
            var authResult = await authorizationService.AuthorizeAsync(User, accessRightEntryId, AccessRightPolicy.Revoke);
            if (!authResult.Succeeded)
                return Forbid();

            await accessRightsService.RevokeAccessRightEntry(accessRightEntryId);
            return NoContent();
        }
    }
}
