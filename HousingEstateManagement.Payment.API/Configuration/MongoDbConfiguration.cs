using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Configuration
{
    public class MongoDbConfiguration
    {
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public string InvoicePaymentCollection { get; set; }
        public string CreditCardInfoCollection { get; set; }
    }
}
