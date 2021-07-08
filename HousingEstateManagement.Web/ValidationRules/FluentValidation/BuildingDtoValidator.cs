using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class BuildingDtoValidator:AbstractValidator<BuildingDto>
    {
        public BuildingDtoValidator()
        {
            RuleFor(x => x.BuildingName).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.BuildingName).MaximumLength(1).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(x => x.TotalFlat).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.TotalFlat).Must(x => x >= 1 && x <= 20).WithMessage(ConstantValidationMessages.TotalFlatMessage);
        }
        public override ValidationResult Validate(ValidationContext<BuildingDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("BuildingDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}