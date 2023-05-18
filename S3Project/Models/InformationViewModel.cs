namespace S3Project.Models
{
    public class InformationViewModel
    {
        public string deviceId { get; set; }
        public string deviceType { get; set; }
        public string deviceName { get; set; }
        public string groupId { get; set; }
        public string dataType { get; set; }
        public DataViewModel data { get; set; }
        public double timestamp { get; set; }
    }

    public class DataViewModel
    {
        public bool fullPowerMode { get; set; }
        public bool activePowerControl { get; set; }
        public int firmwareVersion { get; set; }
        public int temperature { get; set; }
        public int humidity { get; set; }
        public int version { get; set; }
        public string? messageType { get; set; }
        public bool occupancy { get; set; }
        public int stateChanged { get; set; }
    }
}
