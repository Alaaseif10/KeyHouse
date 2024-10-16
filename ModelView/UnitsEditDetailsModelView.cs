using System.ComponentModel.DataAnnotations;
using static KeyHouse.Models.Enums;

namespace KeyHouse.ModelView
{
    public class UnitsEditDetailsModelView
    {
        public int UnitId { get; set; }
        public PropertyType Unit_Title { get; set; } // flat or villa or ....
        public PropertySellType Type_Rent { get; set; } // rent or sell  ....
        public PropertyCategory Type_Unit { get; set; } // skanie or edare  ....
        public Under_constracting_Status Under_constracting_Status { get; set; }  //1=> ready , 2=> under_construction

        [Required(ErrorMessage = "Description is required.")]
        public string Unit_Description { get; set; }
        public int? Num_Rooms { get; set; }
        public int? Num_Bathrooms { get; set; }
        [Required(ErrorMessage = "Area is required.")]
        public int Area { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public bool Furnishing { get; set; }
        public int GovernmentId { get; set; }
        public int CityId { get; set; }
        public int BlockId { get; set; }

        // to list ids of selected services
        public List<int> SelectedServices { get; set; }
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
        public List<string> ExistingImages { get; set; } = new List<string>();// Store image URLs or paths

    }
}
