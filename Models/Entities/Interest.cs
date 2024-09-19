namespace KeyHouse.Models.Entities
{
    public class Interest
    {
        public int UsersId { get; set; }
        public int UnitsId { get; set; }
        public bool SuccessfulContact { get; set; }  
        public DateTime Interest_AddedDate { get; set; }

        // Relations
        public virtual Users? Users { get; set; }
        public virtual Units? Units { get; set; }

    }
}
