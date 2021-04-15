using FluentValidation;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandValidator : AbstractValidator<UpdateApplicantCommand>
    {
        public UpdateApplicantCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

        }
    }
}
