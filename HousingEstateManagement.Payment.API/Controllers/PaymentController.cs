using HousingEstateManagement.Payment.API.Models;
using HousingEstateManagement.Payment.API.Models.DTOs;
using HousingEstateManagement.Payment.API.Models.Entities;
using HousingEstateManagement.Payment.API.Services.Interfaces;
using HousingEstateManagement.Payment.API.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICreditCardInfoService _creditCardInfoService;
        public PaymentController(IInvoiceService invoiceService , ICreditCardInfoService creditCardInfoService)
        {
            _invoiceService = invoiceService;
            _creditCardInfoService = creditCardInfoService;
        }
        [Route("CreatePayment")]
        [HttpPost]
        public async Task<ApiResponse<string>> CreatePayment(CreateInvoicePaymentDto createPaymentDto)
        {
            var validator = new CreateInvoicePaymentValidator();
            var results = validator.Validate(createPaymentDto);
            if (!results.IsValid)
            {
                return InternalServerError(results.ToString());
            }

            var creditCardResult = await _creditCardInfoService.GetByFilter(createPaymentDto);

            if (creditCardResult == null)
            {
                return InternalServerError("Geçersiz kredi kartı/ Kredi kartı bulunamadı.");
            }
            if (creditCardResult.Balance <= createPaymentDto.InvoiceAmount)
            {
                return InternalServerError("Yetersiz bakiye.");
            }
            var createInvoicePayment = new InvoicePayment()
            {
                CardNumber = createPaymentDto.CardNumber,
                Owner = createPaymentDto.Owner,
                Cvv = createPaymentDto.Cvv,
                InvoiceAmount = createPaymentDto.InvoiceAmount,
                ValidMonth = createPaymentDto.ValidMonth,
                ValidYear = createPaymentDto.ValidYear,
                FlatId = createPaymentDto.FlatId,
                ExpenseId = createPaymentDto.ExpenseId
            };
            creditCardResult.Balance -= createPaymentDto.InvoiceAmount;

            //TODO: Bu iki satır için transaction scope açılacak.
            await _creditCardInfoService.Update(creditCardResult.Id, creditCardResult);
            await _invoiceService.Add(createInvoicePayment);
            return Success(createInvoicePayment.Id);
        }

        [Route("CreateCreditCard")]
        [HttpPost]
        public async Task<string> CreateCreditCard(CreditCardInfoDto creditCardInfoDto)
        {
            var createCreditCard = new CreditCardInfo()
            {
                CardNumber = creditCardInfoDto.CardNumber,
                Owner = creditCardInfoDto.Owner,
                Cvv = creditCardInfoDto.Cvv,
                Balance = creditCardInfoDto.Balance,
                ValidMonth = creditCardInfoDto.ValidMonth,
                ValidYear = creditCardInfoDto.ValidYear,
            };

            await _creditCardInfoService.Add(createCreditCard);

            return "Succes";
        }

        [Route("GetCreditCard")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var creditcartfan = await _creditCardInfoService.GetAllAsync();
            return Ok(creditcartfan);

        }

        private ApiResponse<string> Success(string data)
        {
            return new ApiResponse<string>
            {
                Data = data,
                Message = "İşlem başarılı",
                StatusCode = StatusCodes.Status200OK
            };
        }

        private ApiResponse<string> InternalServerError(string errorMessage)
        {
            return new ApiResponse<string>
            {
                Data = null,
                Message = errorMessage,
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

    }
}
