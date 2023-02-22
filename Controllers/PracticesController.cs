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
                s => new PracticeDTO
                {
                    Id = s.Id,
                    practiceName = s.practice_name,
                    date = s.date,
                    overAllLength = s.overall_length,                   
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }










    }
}
