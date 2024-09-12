namespace KeyHouse.Models.Entities
{
    public class Governments
    {
        public int Id { get; set; }
        public required string Government_Name { get; set; }
        public virtual ICollection<Cities> Cities { get; set; } = new List<Cities>();

    }
}
