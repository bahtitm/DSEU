using FluentValidation;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;

namespace DSEU.Application.Modules.Commons.Currencies.Commands.EditCurrency
{
    public class EditCurrencyCommandValidator : AbstractValidator<EditCurrencyCommand>
    {
        public EditCurrencyCommandValidator(ILocalizationService localizationService)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(60)
                .WithName(localizationService[LocalizationKeys.PropertyNames.Name]);

            RuleFor(p => p.NumericCode)
                .NotEmpty()
                .Length(3)
                .WithName(localizationService[LocalizationKeys.PropertyNames.NumericCode]);
            RuleFor(p => p.AlphaCode)
                .NotEmpty()
                .Length(3)
                .WithName(localizationService[LocalizationKeys.PropertyNames.AlphaCode]);
            RuleFor(p => p.ShortName)
                .MaximumLength(60)
                .NotEmpty()
                .WithName(localizationService[LocalizationKeys.PropertyNames.ShortName]);
            RuleFor(p => p.FractionName)
                .MaximumLength(20)
                .NotEmpty()
                .WithName(localizationService[LocalizationKeys.PropertyNames.FractionName]);
        }
    }
}
