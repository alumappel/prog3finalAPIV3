using Microsoft.EntityFrameworkCore.Metadata;

namespace prog3finalAPIV3.DTO
{
    public class PracticeDTO
    {
        
        public int Id { get; set; }
        public string practiceName { get; set; }
        public DateTime date { get; set; }
        public double overAllLength { get; set; }
        public LocationInFrameDTO locationInFrame { get; set; }
        public PitchDTO pitch { get; set; }
        public VolumeDTO volume { get; set; }

    }
}
