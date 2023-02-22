﻿namespace prog3finalAPIV3.Entities
{
    public class Location_In_Frame
    {
        public int Id { get; set; }
        public double measurement_time { get; set; }
        public double good_performance_time_percent { get; set; }
        public double out_of_frame_performance_time_percent { get; set; }
        public double too_close_performance_time_percent { get; set; }
        public double too_far_performance_time_percent { get; set; }
        public int practices_Id { get; set; }
    }
}
