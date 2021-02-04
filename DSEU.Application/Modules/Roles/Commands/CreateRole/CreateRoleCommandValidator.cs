using FluentValidation;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;

namespace DSEU.Application.Modules.Roles.Commands.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator(ILocalizationService localizationService, IReadOnlyApplicationDbContext dbContext)
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(60)
                .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);
        }
    }
}
