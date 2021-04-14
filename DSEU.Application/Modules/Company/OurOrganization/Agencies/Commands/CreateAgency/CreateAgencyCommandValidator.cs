using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.CreateAgency
{
    public class CreateAgencyCommandValidator : AbstractValidator<CreateAgencyCommand>
    {
        public CreateAgencyCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}
