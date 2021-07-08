using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.FirstName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(x => x.LastName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.LastName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(x => x.UserName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.UserName).MaximumLength(200).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(x => x.Email).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ConstantValidationMessages.Email);
            RuleFor(x => x.IdentificationNumber).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.IdentificationNumber).MaximumLength(11).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(x => x.CarLicensePlate).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.CarLicensePlate).MaximumLength(20).WithMessage(ConstantValidationMessages.MaxLength);
        }
        public override ValidationResult Validate(ValidationContext<RegisterDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("RegisterDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}