using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;

namespace KeyHouse.ModelView
{
    public class AgencyDashboardViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string saleType { get; set; }
        public string location { get; set; }
        public float price { get; set; }
        public int status { get; set; }
        public List<Users> InterestedUsers { get; set; }

    }
}
