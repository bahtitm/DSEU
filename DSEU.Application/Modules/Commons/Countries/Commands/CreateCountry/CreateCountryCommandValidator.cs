using FluentValidation;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;

namespace DSEU.Application.Modules.Commons.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator(ILocalizationService localizationService)
        {
            RuleFor(country => country.Name)
                .NotEmpty()
                .MaximumLength(60)
            .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);

        }
    }
}
