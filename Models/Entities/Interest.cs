namespace KeyHouse.Models.Entities
{
    public class Interest
    {
        public bool SuccessfulContact { get; set; }  
        public DateTime Interest_AddedDate { get; set; }

        // Relations
        public virtual Users? Users { get; set; }
        public virtual Units? Units { get; set; }

    }
}
