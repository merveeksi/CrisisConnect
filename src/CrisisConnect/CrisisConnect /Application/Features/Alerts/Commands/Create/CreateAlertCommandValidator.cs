using Core.Application.Common;
using Domain.Enums;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Features.Alerts.Commands.Create;

public class CreateAlertCommandValidator : AbstractValidator<CreateAlertCommand>
{
    public CreateAlertCommandValidator(IStringLocalizer<CreateAlertCommandValidator> localizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Name)])
            .Length(2, 1000).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween,nameof(x.Name),2,1000]);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Description)])
            .Length(2, 4000).WithMessage(x =>
                localizer[CommonLocalizationKeys.ValidationMustBeBetween, nameof(x.Name), 2, 4000]);
           // .Matches("^[a-zA-Z0-9 ,.]*$").WithMessage(x=>localizer[CommonLocalizationKeys.ValidationNotContainSpecialCharacters,nameof(x.Description)]);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Address)]);

        RuleFor(x => x.Instructions)
            .Length(2, 4000).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween,nameof(x.Name),2,4000])
            .When(x => !string.IsNullOrEmpty(x.Instructions)) // Sadece talimatlar varsa kontrol et
            .Matches("^[a-zA-Z0-9 ,.]*$").WithMessage("Talimatlar yalnızca belirli karakterler içerebilir.");
    }
    
    private void ConfigureEnumRules(IStringLocalizer<CreateAlertCommandValidator> localizer)
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Type)])
            .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.Type)]);

        RuleFor(x => x.Severity)
            .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.Severity)])
            .WithMessage("Önem derecesi belirtilmelidir."); // Varsayılan olmayan bir değer olmalı

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.Status)]);
    }
}
