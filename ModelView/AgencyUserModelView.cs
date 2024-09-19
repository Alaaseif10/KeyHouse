namespace KeyHouse.ModelView
{
    public class AgencyUserModelView
    {
        public required string Agency_Name { get; set; }
        public required string Agency_Description { get; set; }
        public required int NumCompany { get; set; }
        public required string AgencyContactEmail { get; set; }
        public required string AgencyContactPhone { get; set; }
        public required string logo { get; set; } 
        public required string  AgencyUesrEmail { get; set; }
        public required string AgencyUserPassword { get; set; }
    }
}
