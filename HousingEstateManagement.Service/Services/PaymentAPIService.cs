using HousingEstateManagement.Core.PaymentApiModel;
using HousingEstateManagement.Core.Services.APIServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagement.Service.Services
{
    public class PaymentAPIService : IPaymentAPIService
    {
        private readonly HttpClient _httpClient;
        public PaymentAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<string>> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            const string requestUri= "http://localhost:29161/api/payment/createpayment";

            string requestJson = JsonConvert.SerializeObject(createPaymentDto);

            HttpResponseMessage httpResponse;
            using (var stringcontent = new StringContent(requestJson,Encoding.UTF8,"application/json"))
            {
                httpResponse = await _httpClient.PostAsync(requestUri, stringcontent);
                var apiResponse = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);
            }
        }
    }
}
