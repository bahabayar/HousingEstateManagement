using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class UpdateExpenseValidator:AbstractValidator<UpdateExpenseDto>
    {
        public UpdateExpenseValidator()
        {
            RuleFor(x => x.IsPaid).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
        }
        public override ValidationResult Validate(ValidationContext<UpdateExpenseDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("UpdateExpenseDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}