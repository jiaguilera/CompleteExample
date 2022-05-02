using CompleteExample.Entities;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    public interface IEnrollmentCommands
    {
        ValueTask<Result<Enrollment>> AddOrUpdateStudentsGradeAsync(int CourseId, int StudentId, decimal? grade);
    }
}