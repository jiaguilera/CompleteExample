using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    public class EnrollmentQueriesTest : TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ByInstructor_Instructor1_HasAllEnrollments()
        {
            var subject = new EnrollmentQueries(_context);
            var result = await subject.ByInstructor(_instructor1.InstructorId);

            Assert.AreEqual(8, result.Count());
        }

        [Test]
        public async Task ByInstructor_Instructors2_HasNoEnrollments()
        {
            var subject = new EnrollmentQueries(_context);
            var result = await subject.ByInstructor(_instructor2.InstructorId);

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public async Task ByInstructor_TopStudents_Works()
        {
            var subject = new EnrollmentQueries(_context);
            var result = await subject.TopStudents();

            Assert.AreEqual(5, result.Count());
            Assert.IsTrue(result.Any(x => x.CourseId == _course1.CourseId && x.StudentId == _student1.StudentId));
            Assert.IsTrue(result.Any(x => x.CourseId == _course1.CourseId && x.StudentId == _student3.StudentId));
            Assert.IsTrue(result.Any(x => x.CourseId == _course1.CourseId && x.StudentId == _student4.StudentId));
            Assert.IsTrue(result.Any(x => x.CourseId == _course3.CourseId && x.StudentId == _student3.StudentId));
            Assert.IsTrue(result.Any(x => x.CourseId == _course3.CourseId && x.StudentId == _student4.StudentId));

            Assert.IsFalse(result.Any(x => x.CourseId == _course1.CourseId && x.StudentId == _student2.StudentId));
            Assert.IsFalse(result.Any(x => x.CourseId == _course3.CourseId && x.StudentId == _student1.StudentId));
            Assert.IsFalse(result.Any(x => x.CourseId == _course3.CourseId && x.StudentId == _student2.StudentId));
        }
    }
}