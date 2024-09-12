namespace KeyHouse.Models.Entities
{
    public class Images
    {
        public int Id { get; set; }
        public string Img_Path { get; set; }
        // image_name meaning 

        //Relations
        public virtual Units? Units { get; set; }

    }
}
