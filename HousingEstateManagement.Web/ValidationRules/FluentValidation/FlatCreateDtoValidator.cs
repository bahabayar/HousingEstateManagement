using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class FlatCreateDtoValidator:AbstractValidator<FlatCreateDto>
    {
        public FlatCreateDtoValidator()
        {
            RuleFor(x => x.FlatNumber).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.TypeOfFlat).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.BuildingId).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
        }
        public override ValidationResult Validate(ValidationContext<FlatCreateDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("FlatCreateDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}