using FluentValidation;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.CreateJobTitle
{
    public class CreateJobTitleCommandValidator : AbstractValidator<CreateJobTitleCommand>
    {
        public CreateJobTitleCommandValidator()
        {
            RuleFor(employeePos => employeePos.Name).NotEmpty();
        }
    }
}
