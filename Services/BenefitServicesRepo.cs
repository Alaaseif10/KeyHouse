using KeyHouse.container;
using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Services
{
    public class BenefitServicesRepo

    {
        KeyHouseDB context;
        public BenefitServicesRepo(KeyHouseDB _context)
        {
            context = _context;
        }


        public List<BenefitsServices> getServices() {
           var result = context.BenefitsServices.ToList();
            return result;  
        }
    }
}
