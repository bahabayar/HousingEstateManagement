using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Models.DTOs
{
    public class CreateInvoicePaymentDto
    {
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public int ValidMonth { get; set; }
        public int ValidYear { get; set; }
        public int Cvv { get; set; }
        public int FlatId { get; set; }
        public int ExpenseId { get; set; }
        public decimal InvoiceAmount { get; set; }
    }
}
