using Core.Application.Common;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Features.Donors.Commands.Create;

public class CreateDonorCommandValidator:AbstractValidator<CreateDonorCommand>
{
    public CreateDonorCommandValidator(IStringLocalizer<CreateDonorCommandValidator> localizer)
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.FullName)])
            .Length(2, 50).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween,nameof(x.FullName),2,50]);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Email)])
            .EmailAddress().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.Email)]);

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[\d\s-]{10,}$").WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.PhoneNumber)]);
        
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Location)])
            .Length(2, 100).WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween,nameof(x.Location),2,100]);
        
    }
}