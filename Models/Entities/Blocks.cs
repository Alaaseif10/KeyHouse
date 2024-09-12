namespace KeyHouse.Models.Entities
{
    public class Blocks
    {
        public int Id { get; set; }
        public string Block_Name { get; set; }
        public virtual Cities? Cities { get; set; }
    }
}
