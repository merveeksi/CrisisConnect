using Core.Application.Common;
using Core.CrossCuttingConcerns.Localizations;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Features.Logistics.Commands.Create;

public class CreateLogisticCommandValidator:AbstractValidator<CreateLogisticCommand>
{
    public CreateLogisticCommandValidator(IStringLocalizer<CreateLogisticCommandValidator> localizer)
    {
        RuleFor(x => x.VehicleType)
            .IsInEnum().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsInvalid,nameof(x.VehicleType)]);

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.");

        RuleFor(x => x.StartLocation)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.StartLocation)]);

        RuleFor(x => x.EndLocation)
            .NotEmpty().WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.EndLocation)]);

        // RuleFor(x => x.EstimatedArrivalTime)
        //     .GreaterThan(DateTime.Now).WithMessage(x => localizer[CommonLocalizationKeys.ValidationDatetimeNotFuture,nameof(x.EstimatedArrivalTime)]);
    }
}