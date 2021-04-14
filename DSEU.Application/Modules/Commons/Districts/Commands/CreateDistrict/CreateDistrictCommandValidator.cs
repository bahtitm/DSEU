using FluentValidation;

namespace DSEU.Application.Modules.Commons.Districts.Commands.CreateDistrict
{
    public class CreateDistrictCommandValidator : AbstractValidator<CreateDistrictCommand>
    {
        public CreateDistrictCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.DistrictCode)
                .NotEmpty();

            RuleFor(p => p.RegionId)
                .NotEmpty();
        }
    }
}
