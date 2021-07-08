using HousingEstateManagement.Payment.API.Models.DTOs;
using HousingEstateManagement.Payment.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Services.Interfaces
{
   public interface ICreditCardInfoService
    {
        Task<List<CreditCardInfo>> GetAllAsync();
        Task<CreditCardInfo> GetById(string id);
        Task<CreditCardInfo> GetByFilter(CreateInvoicePaymentDto filter);
        Task Add(CreditCardInfo creditCardInfo);
        Task Delete(string id);
        Task Update(string id, CreditCardInfo creditCardInfo);
    }
}
