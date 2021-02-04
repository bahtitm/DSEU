using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Roles.Commands.RemoveRole
{
    public class RemoveRoleCommandValidator : AbstractValidator<RemoveRoleCommand>
    {
        public RemoveRoleCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            RuleFor(p => p.Id)
                .MustAsync(async (id, ct) => !await dbContext.Query<Role>().AnyAsync(p => p.Id == id && p.IsSystem))
                .WithMessage(localizationService[LocalizationKeys.RoleKeys.CantUpdateSystemRole]);
        }
    }
}
