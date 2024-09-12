namespace KeyHouse.Models.Entities
{
    public class Interest
    {
        public Boolean SuccessfulContact { get; set; }  
        public DateTime Interest_AddedDate { get; set; }
        public virtual Users? Users { get; set; }
        public virtual Units? Units { get; set; }

    }
}
