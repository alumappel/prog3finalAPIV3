using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prog3finalAPIV3.DTO;
using prog3finalAPIV3.Entities;
using System.Net;

namespace prog3finalAPIV3.Controllers
{
    [ApiController]
    [Route("api/Practices")]
    public class PracticesController : Controller
    {
        private readonly DBContext DBContext;

        public PracticesController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }


        [HttpGet("GetPractices")]
        public async Task<ActionResult<List<PracticeDTO>>> Get()
        {
            var List = await DBContext.Practices.Select(
                p => new PracticeDTO
                {
                    Id = p.Id,
                    practiceName = p.practice_name,
                    date = p.date,
                    overAllLength = p.overall_length,
                    //locationInFrame = DBContext.LocationInFrame.Select(
                    //    l => new LocationInFrameDTO
                    //    {
                    //        Id = l.Id,
                    //        measurmentTime = l.measurment_time,
                    //        goodPTP = l.good_preformance_time_percent,
                    //        outOfFramePTP = l.out_of_frame_preformance_time_percent,
                    //        tooClosePTP = l.too_close_preformance_time_percent,
                    //        tooFarPTP = l.too_far_preformance_time_percent,
                    //        practiceId = l.practice_Id

                    //    }
                    //).FirstOrDefaultAsync(l => l.practice_Id == p.Id);
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                foreach(PracticeDTO p in List) {
                    p.locationInFrame = await DBContext.Location_In_Frame.Select(
                        l => new DTO.LocationInFrameDTO
                        {
                            Id = l.Id,
                            measurmentTime = l.measurement_time,
                            goodPTP = l.good_performance_time_percent,
                            outOfFramePTP = l.out_of_frame_performance_time_percent,
                            tooClosePTP = l.too_close_performance_time_percent,
                            tooFarPTP = l.too_far_performance_time_percent,
                            practiceId = l.practices_Id

                        }
                    ).FirstOrDefaultAsync(l => l.practiceId == p.Id);
                }
                return List;
            }
        }










    }
}
