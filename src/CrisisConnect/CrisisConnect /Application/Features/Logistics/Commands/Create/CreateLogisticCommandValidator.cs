using FluentValidation;

namespace Application.Features.Logistics.Commands.Create;

public class CreateLogisticCommandValidator:AbstractValidator<CreateLogisticCommand>
{
    public CreateLogisticCommandValidator()
    {
        RuleFor(x => x.VehicleType)
            .IsInEnum().WithMessage("Geçersiz araç tipi.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.");

        RuleFor(x => x.StartLocation)
            .NotEmpty().WithMessage("Başlangıç konumu boş olamaz.");

        RuleFor(x => x.EndLocation)
            .NotEmpty().WithMessage("Varış konumu boş olamaz.");

        RuleFor(x => x.EstimatedArrivalTime)
            .GreaterThan(DateTime.Now).WithMessage("Tahmini varış zamanı gelecekte olmalıdır.");
    }
}