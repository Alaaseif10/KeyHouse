namespace KeyHouse.Models.Entities
{
    public class Agencies : Users
    {
        //public int Id { get; set; }
        public  string AgencyName { get; set; }
        public  string AgencyDescription { get; set; }
        public int AgencyStatus { get; set; } // 1=> pending , 2=> rejected , 3=> accepted , 4 => suspend
        public int NumCompany {  get; set; }
        //public  string AgencyContactEmail { get; set; }
        //public  string AgencyContactPhone { get; set; }
        public string logo { get; set; } // string 

        // Relations
        //public virtual Users? Users { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; } = new List<Contracts>();
        public virtual ICollection<Units> Units { get; set; } = new List<Units>();





    }
}
