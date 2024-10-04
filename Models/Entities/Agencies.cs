namespace KeyHouse.Models.Entities
{
    public class Agencies : Users
    {
        public int Id { get; set; }
        public  string Agency_Name { get; set; }
        public  string Agency_Description { get; set; }
        public int Agency_Status { get; set; } // 1=> pending , 2=> rejected , 3=> accepted
        public int NumCompany {  get; set; }
        //public  string AgencyContactEmail { get; set; }
        //public  string AgencyContactPhone { get; set; }
        //public  string logo { get; set; } // binary or string 

        // Relations
        //public virtual Users? Users { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; } = new List<Contracts>();
        public virtual ICollection<Units> Units { get; set; } = new List<Units>();





    }
}
