namespace KeyHouse.Models.Entities
{
    public class Contracts
    {
        public int Id { get; set; }
        public string Contract_Name { get; set; } // check name 
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        //Relations 
        public virtual Agencies? Agencies { get; set; }

    }
}
