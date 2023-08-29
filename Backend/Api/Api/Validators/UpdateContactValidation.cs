using Application.Models;
using FluentValidation;
using Infrastructure.Entities;
using Infrastructure.Enums;
using System.Text.RegularExpressions;

namespace Api.Validators
{
    public class UpdateContactValidation : AbstractValidator<Contact>
    {
        public UpdateContactValidation()
        {
            RuleFor(dto => dto.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(dto => dto.LastName).NotEmpty().MaximumLength(50);
            RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
            RuleFor(dto => dto.Password).NotEmpty().MinimumLength(8).Must(BeStrongPassword).WithErrorCode("Password must be strong.");
            RuleFor(dto => dto.Category).IsInEnum();
            RuleFor(dto => dto.Subcategory).NotEmpty().When(dto => dto.Category == ContactCategory.Other);
            RuleFor(dto => dto.Phone).NotEmpty().Matches(@"^[0-9]+$").Length(6, 12);
            RuleFor(dto => dto.BirthDate).NotEmpty().Must(BeAValidBirthDate);
        }

        private bool BeStrongPassword(string password)
        {
            var lowercaseRequired = new Regex(@"[a-z]");
            var uppercaseRequired = new Regex(@"[A-Z]");
            var digitRequired = new Regex(@"[0-9]");
            var specialCharacterRequired = new Regex(@"[!@#$%^&*]");

            return lowercaseRequired.IsMatch(password)
                && uppercaseRequired.IsMatch(password)
                && digitRequired.IsMatch(password)
                && specialCharacterRequired.IsMatch(password);
        }
        private bool BeAValidBirthDate(DateTime birthDate)
        {
            return birthDate < DateTime.Now;
        }
    }
}
