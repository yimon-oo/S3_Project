using System.ComponentModel.DataAnnotations.Schema;

namespace S3Project.Entities
{
    [Table("information")]
    public class Information
    {
        public int id { get; set; }
        public string deviceId { get; set; }
        public string deviceType { get; set; }
        public string deviceName { get; set; }
        public string groupId { get; set; }
        public string dataType { get; set; }
        public int data_id { get; set; }
        public DateTime timestamp { get; set; }
    }
}
