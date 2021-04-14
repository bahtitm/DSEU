using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.UpdateJobTitle
{
    public class UpdateJobTitleCommandValidator : AbstractValidator<UpdateJobTitleCommand>
    {
        public UpdateJobTitleCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}
