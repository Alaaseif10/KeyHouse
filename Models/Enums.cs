namespace KeyHouse.Models
{
    public class Enums
    {
        public enum PropertySellType
        {
            Rent = 1,
            Sale = 2
        }
        public enum PropertyCategory
        {
            Residential = 1,
            Commercial = 2
        }

        public enum PropertyType
        {
            // Residential Types
            Apartment = 1,
            Villa = 2,
            House = 3,
            Duplex =4,

            // Commercial Types
            Office = 5,
            Shop = 6,
            Warehouse = 7,
            Factory = 8
        }

        public enum Under_constracting_Status
        {
            Ready = 1,
            under_construction =2,
        }


    }
}
