namespace Core.CrossCuttingConcerns.Localizations;

public static class CommonLocalizationKeys
{
    public static string GeneralValidationException => nameof(GeneralValidationException);
    public static string GeneralNotFoundException => nameof(GeneralNotFoundException);
    public static string GeneralInternalServerException => nameof(GeneralInternalServerException);
    public static string ValidationIsRequired => nameof(ValidationIsRequired);
    public static string ValidationIsInvalid => nameof(ValidationIsInvalid);
    public static string ValidationMustBeBetween => nameof(ValidationMustBeBetween);
    public static string ValidationNotContainSpecialCharacters => nameof(ValidationNotContainSpecialCharacters);
    public static string ValidationDatetimeNotFuture => nameof(ValidationDatetimeNotFuture);
}