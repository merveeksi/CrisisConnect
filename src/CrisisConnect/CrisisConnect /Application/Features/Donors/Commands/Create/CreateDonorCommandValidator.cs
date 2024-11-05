using FluentValidation;

namespace Application.Features.Donors.Commands.Create;

public class CreateDonorCommandValidator:AbstractValidator<CreateDonorCommand>
{
    public CreateDonorCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad ve soyad alanı boş olamaz.")
            .MinimumLength(3).WithMessage("Ad ve soyad 4 karakterden kısa olamaz.")
            .MaximumLength(50).WithMessage("Ad ve soyad 50 karakterden uzun olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[\d\s-]{10,}$").WithMessage("Geçerli bir telefon numarası giriniz.");
        
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Konum alanı boş olamaz.")
            .MinimumLength(3).WithMessage("Konum 3 karakterden kısa olamaz.")
            .MaximumLength(50).WithMessage("Konum 50 karakterden uzun olamaz.");
        
    }
}