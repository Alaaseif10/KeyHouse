using System.Diagnostics.Contracts;

namespace KeyHouse.Models.Entities
{
    public class Units
    {
        public int Id { get; set; }
        public string Unit_Title { get; set; }
        public string Unit_Description { get; set; }
        //under discussion 
        public int Status { get; set; } // 1=> pending , 2=> is sold , 3=> is rented
        public int Num_Rooms { get; set; }
        public int Num_Bathrooms { get; set; }
        public int Area { get; set; }
        public float Price { get; set; }
        public int Under_constracting_Status { get; set; }  //1=> ready , 2=> under_construction
        public bool Furnishing {  get; set; } 
        public DateTime Added_Date { get; set; }



        // Relations
        public virtual Blocks? Blocks { get; set; }
        public virtual Agencies? Agencies { get; set; }
        //public virtual ICollection<Users> Users { get; set; } = new List<Users>();
        public virtual ICollection<Images>? Images { get; set; } = new List<Images>();

        public virtual ICollection<Interest>? Interests { get; set; } = new List<Interest>();
        public virtual ICollection<BenefitsServices>? BenefitsServices { get; set; } = new List<BenefitsServices>();


        //// 
        //public enum types
        //{
        //    vila, 
        //    apartment,
        //    duplex,
        //}
        ////

    }
}
