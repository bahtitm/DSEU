using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.UpdateUser
{
    public class UpdateUserComandValidator : AbstractValidator<UpdateUserComand>
    {
        public UpdateUserComandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.FirstName)
                .NotEmpty();

            RuleFor(p => p.LastName)
                .NotEmpty();

            RuleFor(p => p.JobTitleId)
                .NotEmpty();

            RuleFor(p => p.DistrictId)
                .NotEmpty();

            RuleFor(p => p.BranchId)
                .NotEmpty();
        }
    }
}
