using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Id)
                .MustAsync(async (id, ct) => !await dbContext.Query<Role>().AnyAsync(p => p.Id == id && p.IsSystem))
                .WithMessage(localizationService[LocalizationKeys.RoleKeys.CantUpdateSystemRole]);
        }
    }
}
