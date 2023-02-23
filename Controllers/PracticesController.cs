using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prog3finalAPIV3.DTO;
using prog3finalAPIV3.Entities;
using System.Linq;
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

        //שליפה של כל האימונים וכל הנתונים
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
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                foreach (PracticeDTO p in List)
                {
                    p.locationInFrame = await DBContext.Location_In_Frame.Select(
                        l => new LocationInFrameDTO
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


                    p.volume = await DBContext.Volume.Select(
                       v => new VolumeDTO
                       {
                           Id = v.Id,
                           measurmentTime = v.measurement_time,
                           volumeAVG = v.volume_avg,
                           goodPTP = v.good_performance_time_percent,
                           tooLoudPTP = v.too_loud_performance_time_percent,
                           tooQuietPTP = v.too_quiet_performance_time_percent,
                           practiceId = v.practices_Id

                       }
                   ).FirstOrDefaultAsync(v => v.practiceId == p.Id);


                    p.pitch = await DBContext.Pitch.Select(
                  pi => new PitchDTO
                  {
                      Id = pi.Id,
                      measurmentTime = pi.measurement_time,
                      goodPTP = pi.good_performance_time_percent,
                      practiceId = pi.practices_Id

                  }
              ).FirstOrDefaultAsync(pi => pi.practiceId == p.Id);

                }
                return List;
            }
        }


        //עדכון שם של אימון
        [HttpPut("UpdatePracticeName/{id}/{newName}")]
        public async Task<HttpStatusCode> UpdatePracticeName(int id, string newName)
        {
            var practiceToChange = await DBContext.Practices.FirstOrDefaultAsync(p => p.Id == id);
            if (practiceToChange != null)
            {
                practiceToChange.practice_name = newName;
            }
            //להוסיף לא נמצא

            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        //מחיקת אימון
        [HttpDelete("DeletePractice/{id}")]
        public async Task<HttpStatusCode> DeletePractice(int id)
        {
            //שליפת האימון
            Practices practiceToDelete= await DBContext.Practices.Select().FirstOrDefaultAsync(practiceToDelete.Id == id);
            if (practiceToDelete == null)
            {
                return NotFound();
            }
            else
            {
                ////מחיקת ווליום
                //Volume volumeToDelete = await DBContext.Volume.Select().FirstOrDefaultAsync(v => v.practices_Id == id);
                //if (volumeToDelete != null)
                //{
                //    DBContext.Volume.Remove(volumeToDelete);
                //}
                ////מחיקת פריים
                //Location_In_Frame locationToDelete = await DBContext.Location_In_Frame.Select().FirstOrDefaultAsync(l => l.practices_Id == id);
                //if (locationToDelete != null)
                //{
                //    DBContext.Location_In_Frame.Remove(locationToDelete);
                //}
                ////מחיקת פיץ'
                //Pitch pitchToDelete = await DBContext.Pitch.Select().FirstOrDefaultAsync(pv => p.practices_Id == id);
                //if (volumeToDelete != null)
                //{
                //    DBContext.Pitch.Remove(pitchToDelete);
                //}

                //מחיקת האימון
                DBContext.Practices.Remove(practiceToDelete);
                await DBContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }

        }








    }
}
