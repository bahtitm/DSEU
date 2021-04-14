using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.UpdateDepartament
{
    public class UpdateDepartamentCommandValidator : AbstractValidator<UpdateDepartamentCommand>
    {
        public UpdateDepartamentCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.AgencyId)
                .NotEmpty();
        }
    }
}
