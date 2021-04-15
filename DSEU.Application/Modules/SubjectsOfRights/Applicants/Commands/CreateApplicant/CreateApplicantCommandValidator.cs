using FluentValidation;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
    {
        public CreateApplicantCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}
