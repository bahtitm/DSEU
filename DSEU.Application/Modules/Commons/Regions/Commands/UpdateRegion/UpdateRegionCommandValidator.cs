using FluentValidation;

namespace DSEU.Application.Modules.Commons.Regions.Commands.UpdateRegion
{
    public class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
    {
        public UpdateRegionCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.RegionCode)
                .NotEmpty();
        }
    }
}
