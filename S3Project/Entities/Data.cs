using System.ComponentModel.DataAnnotations.Schema;

namespace S3Project.Entities
{
    [Table("data")]
    public class Data
    {
        public int id { get;set; }
        public int temperature { get; set; }
        public int humidity { get; set; }
        public bool occupancy { get; set; }
    }
}
