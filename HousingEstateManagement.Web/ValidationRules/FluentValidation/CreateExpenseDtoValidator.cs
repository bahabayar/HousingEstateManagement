using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class CreateExpenseDtoValidator : AbstractValidator<CreateExpenseDto>
    {
        public CreateExpenseDtoValidator()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
        }
        public override ValidationResult Validate(ValidationContext<CreateExpenseDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("CreateExpenseDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}