namespace prog3finalAPIV3.DTO
{
    public class VolumeDTO
    {
        //preformance_time_percent=PTP
        public int Id { get; set; }
        public double measurmentTime { get; set; }
        public double volumeAVG { get; set; }
        public double goodPTP { get; set; }
        public double tooLoudPTP { get; set; }
        public double tooQuietPTP { get; set; }
        public int practiceId { get; set; }
    }
}
