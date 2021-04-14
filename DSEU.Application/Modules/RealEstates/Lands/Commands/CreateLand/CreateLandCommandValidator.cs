using FluentValidation;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.CreateLand
{
    public class CreateLandCommandValidator : AbstractValidator<CreateLandCommand>
    {
        public CreateLandCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

        }
    }
}
