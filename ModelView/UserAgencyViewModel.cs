namespace KeyHouse.ModelView
{
    public class UserAgencyViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public int User_Type { get; set; } // 1=> client , 2=> agency , 3 => admin
        public DateTime Creation_date { get; set; }
        public int status { get; set; } // 1 => active , 2 => not active 
        public string AgencyName { get; set; }

    }
}
