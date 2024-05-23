using Entities.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.MasterPasswordStrength
{
    public class MasterPasswordValidator : AbstractValidator<UserForRegisterDto>
    {
        public MasterPasswordValidator()
        {
            RuleFor(p => p.Password)
                .Must(HasStrongPassword)
                .WithMessage("Weak password. Password should be at least 8 characters and include uppercase, lowercase, digit, and special character.");
        }

        private bool HasStrongPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < 8)
                return false;


            bool hasUppercase = Regex.IsMatch(password, @"[A-Z]");
            bool hasLowercase = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecialChar = Regex.IsMatch(password, @"[^\w]");

            // Password must meet all criteria
            return hasUppercase && hasLowercase && hasDigit && hasSpecialChar;
        }
    }
}
