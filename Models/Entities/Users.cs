namespace KeyHouse.Models.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public required string User_Name { get; set; }
        public required string? Uesr_Email { get; set; }
        public required string User_Password { get; set; }
        public required string User_Phone { get; set; }
        public int User_Type { get; set; } // 1=> client , 2=> agency , 3 => admin
        public DateTime Creation_date  { get; set; }
        public int status {get; set; } // 1 => active , 2 => not active 

        //Relations
        public virtual ICollection<Units> Units { get; set; } = new List<Units>();


    }
}
