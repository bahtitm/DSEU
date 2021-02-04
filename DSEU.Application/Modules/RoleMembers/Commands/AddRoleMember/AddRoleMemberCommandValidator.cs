using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.RoleMembers.Commands.AddRoleMember
{
    public class AddRoleMemberCommandValidator : AbstractValidator<AddRoleMemberCommand>
    {
        public AddRoleMemberCommandValidator(IReadOnlyApplicationDbContext dbContext, ILocalizationService localizationService,
            IRecipientLinkService recipientLinkService)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(command => command)
               .Must((command) => command.MemberId != command.RoleId)
               .WithMessage(localizationService[LocalizationKeys.SharedKeys.CircularNesting]);

            RuleFor(p => p.RoleId)
                .MustAsync(async (roleId, ct) => !await dbContext.Query<Role>().AnyAsync(p => p.Id == roleId && p.Immutable))
                .WithMessage(localizationService[LocalizationKeys.RoleKeys.RoleMembersIsImmutable]);

            RuleFor(p => p)
              .MustAsync(async (command, ct) => !await recipientLinkService.Exists<RoleRecipientLinks>(command.RoleId, command.MemberId))
              .WithMessage(localizationService[LocalizationKeys.RoleKeys.RoleMemberAlreadyAssigned]);

            RuleFor(p => p.MemberId)
              .MustAsync(async (memberId, ct) => await dbContext.Query<SystemUser>().AllAsync(p => p.Id != memberId))
              .WithMessage(localizationService[LocalizationKeys.RoleKeys.RoleMembersIsImmutable]);
        }
    }
}
