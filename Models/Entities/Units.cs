using System.Diagnostics.Contracts;
using static KeyHouse.Models.Enums;

namespace KeyHouse.Models.Entities
{
    public class Units
    {
        public int Id { get; set; }

        // Types ----
        public PropertyType Unit_Title { get; set; } // flat or villa or ....
        public PropertySellType Type_Rent { get; set; } // rent or sell  ....
        public PropertyCategory Type_Unit { get; set; } // skanie or edare  ....
        public Under_constracting_Status Under_constracting_Status { get; set; }  //1=> ready , 2=> under_construction

        public string Unit_Description { get; set; } 
        public int Status { get; set; } // 1=> pending , 2=> is sold , 3=> is rented
        public int? Num_Rooms { get; set; }
        public int? Num_Bathrooms { get; set; }
        public int Area { get; set; }
        public float Price { get; set; }
        public bool Furnishing {  get; set; } 
        public DateTime Added_Date { get; set; }



        // Relations
        public virtual Blocks? Blocks { get; set; }
        public virtual ICollection<Agencies> Agencies { get; set; }
        //public virtual ICollection<Users> Users { get; set; } = new List<Users>();
        public virtual ICollection<Images>? Images { get; set; } = new List<Images>();
        public virtual ICollection<Interest>? Interests { get; set; } = new List<Interest>();
        public virtual ICollection<BenefitsServices>? BenefitsServices { get; set; } = new List<BenefitsServices>();


    }
}
