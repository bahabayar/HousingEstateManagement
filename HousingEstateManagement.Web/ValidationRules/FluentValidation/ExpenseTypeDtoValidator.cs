using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class ExpenseTypeDtoValidator:AbstractValidator<ExpenseTypeDto>
    {
        public ExpenseTypeDtoValidator()
        {
            RuleFor(x => x.ExpenseTypeName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.ExpenseTypeName).MaximumLength(50).WithMessage(ConstantValidationMessages.MaxLength);
        }
        public override ValidationResult Validate(ValidationContext<ExpenseTypeDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("ExpenseTypeDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}