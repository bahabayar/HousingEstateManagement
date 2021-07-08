using HousingEstateManagement.Payment.API.Configuration;
using HousingEstateManagement.Payment.API.Models.Entities;
using HousingEstateManagement.Payment.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Payment.API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private IMongoCollection<InvoicePayment> _invoicePaymentCollection; 
        private MongoDbConfiguration _config;
        public InvoiceService(IOptions<MongoDbConfiguration> config)
        {
            _config = config.Value;
            MongoClient client = new MongoClient(_config.ConnectionString);
            IMongoDatabase db = client.GetDatabase(_config.DbName);
            _invoicePaymentCollection = db.GetCollection<InvoicePayment>(_config.InvoicePaymentCollection);
        }
        public async Task Add(InvoicePayment invoicePayment)
        {
            await _invoicePaymentCollection.InsertOneAsync(invoicePayment);
        }

        public async Task Delete(string id)
        {
            await _invoicePaymentCollection.DeleteOneAsync(x => x.Id == id);

        }

        public async Task<List<InvoicePayment>> GetAll()
        {
            return await _invoicePaymentCollection.Find(x => true).ToListAsync();
           
        }

        public async Task<InvoicePayment> GetById(string id)
        {
            return await _invoicePaymentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
