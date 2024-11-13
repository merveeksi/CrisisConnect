using Application.Features.Alerts.Commands.Create;
using Core.Application.Common;
using Core.CrossCuttingConcerns.Localizations;
using Domain.Enums;
using Domain.ValueObjects;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Features.Disasters.Commands.Create;

public class CreateDisasterCommandValidator : AbstractValidator<CreateDisasterCommand>
{
    public CreateDisasterCommandValidator(IStringLocalizer<CreateDisasterCommandValidator> localizer)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Name)])
            .Length(2, 1000).WithMessage(x =>
                localizer[CommonLocalizationKeys.ValidationMustBeBetween, nameof(x.Name), 2, 1000]);
        
        // Contact information
        RuleFor(c => c.ContactInfo)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.ContactInfo)]);
           
        // Impact Assessment
        RuleFor(c => c.ImpactAssessment)
            .NotEmpty().WithMessage(x =>
                localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.ImpactAssessment)]);
           
        // DateTime Information
        RuleFor(c => c.DateTime)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.DateTime)]);
    }

    private void ConfigureEnumRules(IStringLocalizer<CreateDisasterCommandValidator> localizer)
    {
        RuleFor(c => c.Type)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Type)])
            .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid, nameof(x.Type)]);

        RuleFor(c => c.Status)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Status)])
            .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid, nameof(x.Status)]);
    }
}