using HousingEstateManagement.Payment.API.Models.DTOs;
using HousingEstateManagement.Payment.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Services.Interfaces
{
   public interface IInvoiceService
    {
        Task<List<InvoicePayment>> GetAll();
        Task<InvoicePayment> GetById(string id);
        Task Add(InvoicePayment invoicePayment);
        Task Delete(string id);
    }
}
