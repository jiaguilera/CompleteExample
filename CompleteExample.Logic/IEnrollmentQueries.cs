using CompleteExample.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    public interface IEnrollmentQueries
    {
        ValueTask<IEnumerable<Enrollment>> ByInstructorAsync(int instructorId, CancellationToken cancellationToken = default);

        ValueTask<IEnumerable<Enrollment>> TopStudentsAsync(CancellationToken cancellationToken = default);
    }
}