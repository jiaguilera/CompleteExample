using CompleteExample.Entities;

namespace CompleteExample.API.Controllers
{
    public class EnrollmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Grade { get; set; }

        public static EnrollmentDTO FromEntity(Enrollment entity)
            => entity != default
                ? new EnrollmentDTO { StudentId = entity.StudentId, CourseId = entity.CourseId, Grade = entity.Grade }
                : default;
    }
}