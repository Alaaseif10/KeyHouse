namespace KeyHouse.Models.Entities
{
    public class BenefitsServices
    {
        public int Id { get; set; } 
        public string BenefitsName { get; set; }
        public virtual ICollection<Units>? Units { get; set; } = new List<Units>();

    }
}
