using Microsoft.AspNetCore.Mvc;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Filters;

namespace DSEU.Security.Attributes
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(EntityTypeGuid entityType, AccessRightsOperation operation) : base(typeof(PermissionRequirementFilter))
        {
            Arguments = new object[] { entityType, operation };
        }
    }
}
