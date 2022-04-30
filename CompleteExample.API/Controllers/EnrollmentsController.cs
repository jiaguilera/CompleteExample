using CompleteExample.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CompleteExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpGet("instructor/{instructorId}")]
        public async Task<IEnumerable<EnrollmentDTO>> ByInstructor([FromServices] IEnrollmentQueries queries, int instructorId)
        {
            var results = await queries.ByInstructor(instructorId);

            return results.Select(EnrollmentDTO.FromEntity);
        }

        [HttpGet("topstudents")]
        public async Task<IEnumerable<EnrollmentDTO>> ByInstructor([FromServices] IEnrollmentQueries queries)
        {
            var results = await queries.TopStudents();

            return results.Select(EnrollmentDTO.FromEntity);
        }
    }
}
