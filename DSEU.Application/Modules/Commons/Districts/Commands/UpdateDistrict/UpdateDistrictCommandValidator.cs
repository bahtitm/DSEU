using FluentValidation;

namespace DSEU.Application.Modules.Commons.Districts.Commands.UpdateDistrict
{
    public class UpdateDistrictCommandValidator : AbstractValidator<UpdateDistrictCommand>
    {
        public UpdateDistrictCommandValidator()
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
