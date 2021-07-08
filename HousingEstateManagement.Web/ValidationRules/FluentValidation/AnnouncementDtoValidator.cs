using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace HousingEstateManagement.Web.ValidationRules.FluentValidation
{
    public class AnnouncementDtoValidator:AbstractValidator<AnnouncementDto>
    {
        public AnnouncementDtoValidator()
        {
            RuleFor(x => x.AnnouncementText).NotEmpty().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.AnnouncementText).MaximumLength(1000).WithMessage(ConstantValidationMessages.MaxLength);
        }

        public override ValidationResult Validate(ValidationContext<AnnouncementDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("AnnouncementDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}