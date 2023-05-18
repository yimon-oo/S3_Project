using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace S3Project.Entities
{
    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login_name { get; set; }
        public string password { get; set; }
    }
}
