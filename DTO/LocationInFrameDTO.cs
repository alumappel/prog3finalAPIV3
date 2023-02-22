namespace prog3finalAPIV3.DTO
{
    public class LocationInFrameDTO
    {
        //preformance_time_percent=PTP
        public int Id { get; set; }
        public double measurmentTime { get; set; }
        public double goodPTP { get; set; }
        public double outOfFramePTP { get; set; }
        public double tooClosePTP { get; set; }
        public double tooFarPTP { get; set; }
    }
}
