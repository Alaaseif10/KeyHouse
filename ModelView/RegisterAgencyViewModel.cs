using System.ComponentModel.DataAnnotations;

namespace KeyHouse.ModelView
{
    public class RegisterAgencyViewModel : RegisterViewModel
    {
        [Required]
        public string AgencyName { get; set; }
        [Required]
        public string AgencyDescription { get; set; }
        [Required]
        public int NumCompany { get; set; }
        [Required]
        public IFormFile logo { get; set; }
    }
}
