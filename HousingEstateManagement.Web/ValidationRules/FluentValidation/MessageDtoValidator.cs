using FluentValidation;
using FluentValidation.Results;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Web.ValidationRules.ValidationMessages;

namespace BuildingManager.Web.ValidationRules.FluentValidation
{
    public class MessageDtoValidator:AbstractValidator<MessageDto>
    {
        public MessageDtoValidator()
        {
            RuleFor(x => x.MessageContent).NotNull().WithMessage(ConstantValidationMessages.NotNull);
            RuleFor(x => x.MessageContent).MaximumLength(1000).WithMessage(ConstantValidationMessages.MaxLength);
            RuleFor(x => x.ReceiverId).NotNull().WithMessage(ConstantValidationMessages.NotNull);
        }
        public override ValidationResult Validate(ValidationContext<MessageDto> context)
        {
            return context == null
                ? new ValidationResult(new[] { new ValidationFailure("MessageDto", ConstantValidationMessages.NotNull) })
                : base.Validate(context);
        }
    }
}