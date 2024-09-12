namespace KeyHouse.Models.Entities
{
    public class Cities
    {
        public int Id { get; set; } 
        public string City_Name { get; set; }
        public virtual Governments? Governments { get; set; }
        public virtual ICollection<Blocks> Blocks { get; set; } = new List<Blocks>();
    }
}
