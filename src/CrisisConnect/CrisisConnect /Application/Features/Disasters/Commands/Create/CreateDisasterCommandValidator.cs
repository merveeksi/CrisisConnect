using Application.Features.Alerts.Commands.Create;
using Core.Application.Common;
using Domain.Enums;
using Domain.ValueObjects;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Features.Disasters.Commands.Create;

public class CreateDisasterCommandValidator:AbstractValidator<CreateDisasterCommand>
{
     public CreateDisasterCommandValidator()
    {
        
    }

    private void ConfigureStringRules(IStringLocalizer<CreateDisasterCommandValidator> localizer)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Name)])
            .Length(2, 1000).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween,nameof(x.Name),2,1000]);

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Address)]);

        RuleFor(c => c.EmergencyContactInfo)
            .Length(2, 1000).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween,nameof(x.Address),2,1000]);
    }

    private void ConfigureEnumRules(IStringLocalizer<CreateDisasterCommandValidator> localizer)
    {
        RuleFor(c => c.Type)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Type)])
            .Must(IsValidDisasterType)
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.Type)]);

        RuleFor(c => c.Status)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Status)])
            .Must(IsValidDisasterStatus)
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.Status)]);

        RuleFor(c => c.ImpactAssessment)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.ImpactAssessment)])
            .Must(IsValidImpactAssessment)
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.ImpactAssessment)]);
    }

    private void ConfigureDateRules(IStringLocalizer<CreateDisasterCommandValidator> localizer)
    {
        RuleFor(c => c.DateOccurred)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.DateOccurred)])
            .LessThanOrEqualTo(DateTime.Now).WithMessage(x=>localizer[CommonLocalizationKeys.ValidationDatetimeNotFuture,nameof(x.DateOccurred)]);

        RuleFor(c => c.DateResolved)
            .LessThanOrEqualTo(DateTime.Now).WithMessage(x=>localizer[CommonLocalizationKeys.ValidationDatetimeNotFuture,nameof(x.DateResolved)]);

        RuleFor(c => c.CreatedAt)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.CreatedAt)])
            .LessThanOrEqualTo(DateTime.Now).WithMessage(x=>localizer[CommonLocalizationKeys.ValidationDatetimeNotFuture,nameof(x.CreatedAt)]);

        RuleFor(c => c.LastUpdatedAt)
            .LessThanOrEqualTo(DateTime.Now).WithMessage(x=>localizer[CommonLocalizationKeys.ValidationDatetimeNotFuture,nameof(x.LastUpdatedAt)]);
    }

    private void ConfigureBooleanRules(IStringLocalizer<CreateDisasterCommandValidator> localizer)
    {
        RuleFor(c => c.IsActive)
            .NotNull().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.IsActive)]);
    }

    // Enum doğrulama yardımcıları
    private bool IsValidDisasterType(DisasterType type) => Enum.IsDefined(typeof(DisasterType), type);
    private bool IsValidDisasterStatus(DisasterStatus status) => Enum.IsDefined(typeof(DisasterStatus), status);
    private bool IsValidImpactAssessment(ImpactAssessment assessment) => Enum.IsDefined(typeof(ImpactAssessment), assessment);
}