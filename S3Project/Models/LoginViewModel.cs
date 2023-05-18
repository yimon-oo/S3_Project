using System.ComponentModel.DataAnnotations;


namespace S3Project.Models
{
    public class LoginViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
