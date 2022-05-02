using CompleteExample.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpGet("instructor/{instructorId}")]
        public async Task<IEnumerable<EnrollmentDTO>> ByInstructorAsync([FromServices] IEnrollmentQueries queries, int instructorId)
        {
            var results = await queries.ByInstructorAsync(instructorId);

            return results.Select(EnrollmentDTO.FromEntity);
        }

        [HttpGet("topstudents")]
        public async Task<IEnumerable<EnrollmentDTO>> TopStudentsAsync([FromServices] IEnrollmentQueries queries)
        {
            var results = await queries.TopStudentsAsync();

            return results.Select(EnrollmentDTO.FromEntity);
        }

        [HttpPost()]
        public async Task<IActionResult> AddOrUpdateEnrollmentAsync([FromServices] IEnrollmentCommands commands, EnrollmentDTO enrollment)
        {
            var results = await commands.AddOrUpdateStudentsGradeAsync(enrollment.CourseId, enrollment.StudentId, enrollment.Grade);

            return results.Select<IActionResult>(
                result => Ok(EnrollmentDTO.FromEntity(result)),
                error => BadRequest(error)
                );
        }
    }
}
