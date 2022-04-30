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
            : this(context.Enrollment.AsNoTracking())
        {
        }

        internal EnrollmentQueries(IQueryable<Enrollment> collection)
        {
            _collection = collection;
        }

        public async Task<IEnumerable<Enrollment>> ByInstructor(int instructorId)
        {
            return await _collection
                .Where(e => e.Course.InstructorId == instructorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> TopStudents()
        {
            var topByCourse = await _collection
                .GroupBy(e => e.CourseId)
                .Select(c => c.OrderByDescending(e => e.Grade).Take(3))
                .ToListAsync();

            return topByCourse.SelectMany(x => x);
        }
    }
}
