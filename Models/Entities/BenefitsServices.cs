namespace KeyHouse.Models.Entities
{
    public class BenefitsServices
    {
        public int Id { get; set; } 
        public string BenefitsName { get; set; }

        // pending 
        // benefits type (category) => need another table or not divide them into categories 
        public virtual ICollection<Units>? Units { get; set; } = new List<Units>();

    }
}
