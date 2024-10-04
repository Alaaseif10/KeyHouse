using Microsoft.AspNetCore.Identity;

namespace KeyHouse.Models.Entities
{
    public class Users : IdentityUser
    {
        public int Id { get; set; }
        //public  string User_Name { get; set; }
        //public  string? Uesr_Email { get; set; }
        //public  string User_Password { get; set; }
        //public  string User_Phone { get; set; }
        public int User_Type { get; set; } // 1=> client , 2=> agency , 3 => admin
        public DateTime Creation_date  { get; set; }
        public int status {get; set; } // 1 => active , 2 => not active 

        //Relations
        public virtual Agencies? Agencies { get; set; }

        //public virtual ICollection<Units> Units { get; set; } = new List<Units>();
        public virtual ICollection<Interest>? Interests { get; set; } = new List<Interest>();
        



    }
}
