using System;
using System.Collections.Generic;

namespace HousingEstateManagement.Core.Dtos
{
    public class CreateExpenseDto
    {
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public int FlatId { get; set; }

        public string ExpenseTypeName { get; set; }

        public byte FlatNumber { get; set; }
        public IEnumerable<ExpenseTypeDto> ExpenseTypes { get; set; }
        public IEnumerable<FlatDto> Flats { get; set; }
    }
}