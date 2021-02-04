using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.RoleMembers.Commands.RemoveRoleMember
{
    public class RemoveRoleMemberValidator : AbstractValidator<RemoveRoleMemberCommand>
    {
        public RemoveRoleMemberValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.RoleId)
                .MustAsync(async (roleId, ct) => !await dbContext.Query<Role>().AnyAsync(p => p.Id == roleId && p.Immutable))
                .WithMessage(localizationService[LocalizationKeys.RoleKeys.RoleMembersIsImmutable]);

            RuleFor(p => p.MemberId)
                .MustAsync(async (memberId, ct) => await dbContext.Query<SystemUser>().AllAsync(p => p.Id != memberId))
                .WithMessage(localizationService[LocalizationKeys.RoleKeys.RoleMembersIsImmutable]);
        }
    }
}
