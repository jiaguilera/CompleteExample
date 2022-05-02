using CompleteExample.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    public interface IEnrollmentQueries
    {
        ValueTask<IEnumerable<Enrollment>> ByInstructor(int instructorId);

        ValueTask<IEnumerable<Enrollment>> TopStudents();
    }
}