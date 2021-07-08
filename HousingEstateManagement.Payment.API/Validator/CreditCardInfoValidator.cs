using FluentValidation;
using HousingEstateManagement.Payment.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Validator
{
    public class CreditCardInfoValidator : AbstractValidator<CreditCardInfoDto>
    {
        public CreditCardInfoValidator()
        {
            RuleFor(x => x.Owner).NotEmpty().WithMessage("İsmi Boş geçemezsiniz");
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Kart numarası boş olamaz. ").Length(16).WithMessage("Kredi Kartı Numarası 16 haneden az olamaz");
            RuleFor(x => x.ValidMonth).NotEmpty().WithMessage("Lütfen Bir değer giriniz").InclusiveBetween(1, 12).WithMessage("Değer 1-12 arası olmalıdır");
            RuleFor(x => x.ValidYear).NotEmpty().WithMessage("Lütfen Bir değer giriniz").InclusiveBetween(DateTime.Now.Year, 2100).WithMessage("Geçersiz yıl");
            RuleFor(x => x.Cvv).NotEmpty().WithMessage("Lütfen Bir değer giriniz").Must(x => x >= 100 && x <= 999).WithMessage("Geçersiz CVV");
            RuleFor(x => x.Balance).NotEmpty().WithMessage("Bakiye Boş geçilemez").GreaterThan(0).WithMessage("Bakiye 0'dan az olamaz");


        }
    }
}
