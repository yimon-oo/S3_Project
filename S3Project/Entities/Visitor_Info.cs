using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S3Project.Entities
{
    [Table("visitor_info")]
    public class Visitor_Info
    {
        public int id { get; set; }

        //[Column(TypeName = "ID")]
        public string Name { get; set; }
        public string email { get; set; }
        public string company_name { get; set; }
        public string designation { get; set; }
        public string mobile { get; set; }
        public string license_plate { get; set; }
        public string nric_fin { get; set; }
        public bool issh_notice { get; set; }
        public bool isclose_contact { get; set; }
        public bool isfever { get; set; }
    }
}
