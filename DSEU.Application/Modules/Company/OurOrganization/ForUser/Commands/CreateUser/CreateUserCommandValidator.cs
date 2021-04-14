using FluentValidation;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

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
