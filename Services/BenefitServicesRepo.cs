using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Services
{
    public class BenefitServicesRepo

    {
        KeyHouseDB context = new KeyHouseDB();

        public List<BenefitsServices> getServices() {
           var result = context.BenefitsServices.ToList();
            return result;  
        }
    }
}
