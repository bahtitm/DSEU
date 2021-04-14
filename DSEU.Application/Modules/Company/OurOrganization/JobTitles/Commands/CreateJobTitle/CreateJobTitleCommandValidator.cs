using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Commands.CreateJobTitle
{
    public class CreateJobTitleCommandValidator : AbstractValidator<CreateJobTitleCommand>
    {
        public CreateJobTitleCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();
        }
    }
}
