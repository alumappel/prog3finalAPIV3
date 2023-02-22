namespace prog3finalAPIV3.Entities
{
    public class VolumeDTO
    {
        public int Id { get; set; }
        public double measurment_time { get; set; }
        public double volume_avg { get; set; }
        public double good_preformance_time_percent { get; set; }
        public double too_loud_preformance_time_percent { get; set; }
        public double too_quiet_preformance_time_percent { get; set; }
       
    }
}
