using FluentValidation;

namespace DSEU.Application.Modules.Company.JobTitles.Commands.EditJobTitle
{
    public class EditJobTitleCommandValidator : AbstractValidator<EditJobTitleCommand>
    {
        public EditJobTitleCommandValidator()
        {
            RuleFor(employePos => employePos.Name).NotEmpty();
        }
    }
}
