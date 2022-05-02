using CompleteExample.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    internal class EnrollmentQueries : IEnrollmentQueries
    {
        private readonly IQueryable<Enrollment> _collection;

        public EnrollmentQueries(CompleteExampleDBContext context)
            => _collection = context.Enrollment.AsNoTracking();

        public async ValueTask<IEnumerable<Enrollment>> ByInstructorAsync(int instructorId)
            => await _collection
                .Where(e => e.Course.InstructorId == instructorId)
                .ToListAsync();

        public async ValueTask<IEnumerable<Enrollment>> TopStudentsAsync()
        {
            var topByCourse = await _collection
                .Where(e => e.Grade.HasValue)
                .GroupBy(e => e.CourseId)
                .Select(c => c.OrderByDescending(e => e.Grade).Take(3))
                .ToListAsync();

            return topByCourse.SelectMany(x => x);
        }
    }
}
