using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.UpdateBranch
{
    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.DistrictId)
                .NotEmpty();

            RuleFor(p => p.DepartamentId)
                .NotEmpty();
        }
    }
}
