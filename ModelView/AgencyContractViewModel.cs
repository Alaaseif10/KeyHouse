using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using static KeyHouse.Models.Enums;

namespace KeyHouse.ModelView
{
    public class AgencyContractViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Contract_Name { get; set; } // check name 
        [Required]
        [DataType(DataType.Date)]
        public DateTime Start_date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime End_date { get; set; }
        [DataType(DataType.Text)]
        public string AgencyID { get; set; } // check name 

    }
}
