using FluentValidation;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.UpdateLand
{
    public class UpdateLandCommandValidator : AbstractValidator<UpdateLandCommand>
    {
        public UpdateLandCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}
