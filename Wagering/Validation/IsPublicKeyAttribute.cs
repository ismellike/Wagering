using System.ComponentModel.DataAnnotations;

namespace Wagering.Validation
{
    public class IsPublicKeyAttribute : ValidationAttribute
    {
        public string GetErrorMessage(string? key) =>
        $"{key} is not a valid public key.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string? key = value.ToString();
            return stellar_dotnet_sdk.StrKey.IsValidEd25519PublicKey(key) ? ValidationResult.Success : new ValidationResult(GetErrorMessage(key));
        }
    }
}
