using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.UpdateAgency
{
    public class UpdateAgencyCommandValidator : AbstractValidator<UpdateAgencyCommand>
    {
        public UpdateAgencyCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}
