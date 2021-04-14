using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchCommandValidator()
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
