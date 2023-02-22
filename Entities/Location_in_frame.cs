namespace prog3finalAPIV3.Entities
{
    public class LocationInFrameDTO
    {
        public int Id { get; set; }
        public double measurment_time { get; set; }
        public double good_preformance_time_percent { get; set; }
        public double out_of_frame_preformance_time_percent { get; set; }
        public double too_close_preformance_time_percent { get; set; }
        public double too_far_preformance_time_percent { get; set; }
    }
}
