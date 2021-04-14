using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.CreateRole
{
    public class CreateRoleComandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleComandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.UserClaimTypes)
                .NotEmpty();
        }
    }
}
