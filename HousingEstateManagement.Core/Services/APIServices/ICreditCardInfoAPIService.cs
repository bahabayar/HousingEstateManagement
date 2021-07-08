using HousingEstateManagement.Core.PaymentApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagement.Core.Services.APIServices
{
    public interface ICreditCardInfoAPIService
    {
        Task<List<GetCreditCardDto>> GetAll();
    }
}
