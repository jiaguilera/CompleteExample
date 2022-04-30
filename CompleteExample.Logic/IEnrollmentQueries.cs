using CompleteExample.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    public interface IEnrollmentQueries
    {
        Task<IEnumerable<Enrollment>> ByInstructor(int instructorId);

        Task<IEnumerable<Enrollment>> TopStudents();
    }
}