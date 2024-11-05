using Domain.Enums;
using Domain.ValueObjects;
using FluentValidation;

namespace Application.Features.Disasters.Commands.Create;

public class CreateDisasterCommandValidator:AbstractValidator<CreateDisasterCommand>
{
     public CreateDisasterCommandValidator()
    {
        // String alanlar için doğrulama kurallarını yapılandırıyoruz
        ConfigureStringRules();
        
        // Enum türündeki alanlar için doğrulama kurallarını yapılandırıyoruz
        ConfigureEnumRules();
        
        // Tarih ve zaman alanları için doğrulama kurallarını yapılandırıyoruz
        ConfigureDateRules();
        
        // Boolean alanlar için doğrulama kuralları
        ConfigureBooleanRules();
    }

    private void ConfigureStringRules()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Afet adı boş olamaz.")
            .MinimumLength(2).WithMessage("Afet adı en az 2 karakter olmalı.")
            .MaximumLength(100).WithMessage("Afet adı en fazla 100 karakter olmalı.");

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Adres bilgisi boş olamaz.");

        RuleFor(c => c.EmergencyContactInfo)
            .MaximumLength(100).WithMessage("Acil durum iletişim bilgisi en fazla 100 karakter olmalı.");
    }

    private void ConfigureEnumRules()
    {
        RuleFor(c => c.Type)
            .NotEmpty().WithMessage("Afet türü boş olamaz.")
            .Must(IsValidDisasterType)
            .WithMessage("Geçerli bir afet türü girin (örneğin: Earthquake, Flood, Fire, Landslide, Avalanche, Other).");

        RuleFor(c => c.Status)
            .NotEmpty().WithMessage("Afet durumu boş olamaz.")
            .Must(IsValidDisasterStatus)
            .WithMessage("Geçerli bir afet durumu girin (örneğin: Ongoing, Resolved, Inactive).");

        RuleFor(c => c.ImpactAssessment)
            .NotEmpty().WithMessage("Etki değerlendirmesi boş olamaz.")
            .Must(IsValidImpactAssessment)
            .WithMessage("Geçerli bir etki değerlendirmesi girin.");
    }

    private void ConfigureDateRules()
    {
        RuleFor(c => c.DateOccurred)
            .NotEmpty().WithMessage("Afet gerçekleşme tarihi boş olamaz.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Afet tarihi gelecekte olamaz.");

        RuleFor(c => c.DateResolved)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Afet çözüm tarihi gelecekte olamaz.");

        RuleFor(c => c.CreatedAt)
            .NotEmpty().WithMessage("Oluşturulma tarihi boş olamaz.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Oluşturulma tarihi gelecekte olamaz.");

        RuleFor(c => c.LastUpdatedAt)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Son güncelleme tarihi gelecekte olamaz.");
    }

    private void ConfigureBooleanRules()
    {
        RuleFor(c => c.IsActive)
            .NotNull().WithMessage("Aktiflik bilgisi boş olamaz.");
    }

    // Enum doğrulama yardımcıları
    private bool IsValidDisasterType(DisasterType type) => Enum.IsDefined(typeof(DisasterType), type);
    private bool IsValidDisasterStatus(DisasterStatus status) => Enum.IsDefined(typeof(DisasterStatus), status);
    private bool IsValidImpactAssessment(ImpactAssessment assessment) => Enum.IsDefined(typeof(ImpactAssessment), assessment);
}