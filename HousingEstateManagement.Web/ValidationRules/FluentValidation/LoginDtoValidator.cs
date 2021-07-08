using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class LoginDtoValidator:AbstractValidator<RegisterDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ConstantValidationMessages.Email);
            RuleFor(x => x.Password).NotNull().WithMessage(ConstantValidationMessages.NotNull);
        }
        public override ValidationResult Validate(ValidationContext<RegisterDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("RegisterDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}