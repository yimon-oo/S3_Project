using System.ComponentModel.DataAnnotations.Schema;

namespace S3Project.Models
{
    [Table("location")]
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        public int location_step_id { get; set; }
    }
}
