using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S3Project.Models
{
    public class VisitorInfoViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "This is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "This is required")]
        public string company_name { get; set; }
        public string designation { get; set; }

        [Required(ErrorMessage = "This is required")]
        public string mobile { get; set; }
        public string license_plate { get; set; }
        public string nric_fin { get; set; }
        public bool issh_notice { get; set; }
        public bool isclose_contact { get; set; }
        public bool isfever { get; set; }
    }
}
