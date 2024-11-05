using Domain.Enums;
using FluentValidation;

namespace Application.Features.Alerts.Commands.Create;

public class CreateAlertCommandValidator : AbstractValidator<CreateAlertCommand>
{
    private const int MaxNameLength = 100;
    private const int MaxDescriptionLength = 2000;
    private const int MaxInstructionsLength = 2000;

    public CreateAlertCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Acil durum uyarı ismi boş olamaz.")
            .MaximumLength(MaxNameLength).WithMessage($"İsim {MaxNameLength} karakterden uzun olamaz.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş olamaz.")
            .MaximumLength(MaxDescriptionLength)
            .WithMessage($"Açıklama {MaxDescriptionLength} karakterden uzun olamaz.")
            .Matches("^[a-zA-Z0-9 ,.]*$").WithMessage("Açıklama özel karakter içeremez.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Adres boş olamaz.");

        RuleFor(x => x.Instructions)
            .MaximumLength(MaxInstructionsLength)
            .WithMessage($"Talimatlar {MaxInstructionsLength} karakterden uzun olamaz.")
            .When(x => !string.IsNullOrEmpty(x.Instructions)) // Sadece talimatlar varsa kontrol et
            .Matches("^[a-zA-Z0-9 ,.]*$").WithMessage("Talimatlar yalnızca belirli karakterler içerebilir.");
    }
    
    private void ConfigureEnumRules()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Uyarı tipi boş olamaz.")
            .IsInEnum().WithMessage("Geçersiz uyarı tipi.");

        RuleFor(x => x.Severity)
            .IsInEnum().WithMessage("Geçersiz önem derecesi.")
            .WithMessage("Önem derecesi belirtilmelidir."); // Varsayılan olmayan bir değer olmalı

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Geçersiz durum.");
    }
    
    // Enum doğrulama yardımcıları
    private bool IsValidAlertType(AlertType type) => Enum.IsDefined(typeof(AlertType), type);
    private bool IsValidSeverityLevel(SeverityLevel severity) => Enum.IsDefined(typeof(SeverityLevel), severity);
    private bool IsValidAlertStatus(AlertStatus status) => Enum.IsDefined(typeof(AlertStatus), status);
}
