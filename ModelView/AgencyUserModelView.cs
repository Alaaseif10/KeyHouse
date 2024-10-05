using System.ComponentModel.DataAnnotations;

namespace KeyHouse.ModelView
{
    public class AgencyUserModelView
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Agency_Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Agency_Description { get; set; }

        [Required(ErrorMessage = "Commercial registration number is required.")]
        [MinLength(4, ErrorMessage = "number must be at least 4 characters long.")]
        [MaxLength(6, ErrorMessage = "number must be at less than 7 characters long.")]
        public int NumCompany { get; set; }

        [Required(ErrorMessage = "contact email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string AgencyContactEmail { get; set; }

        [Required(ErrorMessage = "contact phone is required.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Password must be at least 11 characters long.")]
        public string AgencyContactPhone { get; set; }

        [Required(ErrorMessage = "logo is required.")]
        //[FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Please upload an image file (jpg, jpeg, png).")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile logo { get; set; }

        [Required(ErrorMessage = "user email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public  string  AgencyUesrEmail { get; set; }

        [Required(ErrorMessage = "user password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public  string AgencyUserPassword { get; set; }
    }
}
