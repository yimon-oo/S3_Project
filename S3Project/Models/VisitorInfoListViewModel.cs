using System.ComponentModel.DataAnnotations;

namespace S3Project.Models
{
    public class VisitorInfoListViewModel
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string company_name { get; set; }
        public string designation { get; set; }
        public string mobile { get; set; }
        public string license_plate { get; set; }
        public string nric_fin { get; set; }
        public string issh_notice { get; set; }
        public string isclose_contact { get; set; }
        public string isfever { get; set; }
    }
}
