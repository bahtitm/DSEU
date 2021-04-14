using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.CreateDepartament
{
    public class CreateDepartamentCommandValidator : AbstractValidator<CreateDepartamentCommand>
    {
        public CreateDepartamentCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.AgencyId)
                .NotEmpty();
        }
    }
}
