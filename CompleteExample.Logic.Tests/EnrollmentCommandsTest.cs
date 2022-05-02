using CompleteExample.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    public class EnrollmentCommandsTest : TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddOrUpdateStudentsGrade_CourseNotFound_WhenCourseDoesntExist()
        {
            var subject = new EnrollmentCommands(_context);
            var result = await subject.AddOrUpdateStudentsGradeAsync(default, default, default);

            var error = result.Select(_ => string.Empty, error => error);

            Assert.IsTrue(error.Contains(typeof(Course).Name));
            Assert.IsTrue(error.EndsWith("was not found."));
        }

        [Test]
        public async Task AddOrUpdateStudentsGrade_CourseNotFound_WhenCourseDoesntExistAndStudentDoes()
        {
            var subject = new EnrollmentCommands(_context);
            var result = await subject.AddOrUpdateStudentsGradeAsync(default, _student1.StudentId, default);

            var error = result.Select(_ => string.Empty, error => error);

            Assert.IsTrue(error.Contains(typeof(Course).Name));
            Assert.IsTrue(error.EndsWith("was not found."));
        }


        [Test]
        public async Task AddOrUpdateStudentsGrade_StudentNotFound_WhenCourseDoesExistAndStudentDoesnt()
        {
            var subject = new EnrollmentCommands(_context);
            var result = await subject.AddOrUpdateStudentsGradeAsync(_course1.CourseId, default, default);

            var error = result.Select(_ => string.Empty, error => error);

            Assert.IsTrue(error.Contains(typeof(Student).Name));
            Assert.IsTrue(error.EndsWith("was not found."));
        }

        [Test]
        public async Task AddOrUpdateStudentsGrade_EnrollUnexistent_Succeeds()
        {
            Assert.IsFalse(_context.Enrollment.Any(e => e.StudentId == _student1.StudentId && e.CourseId == _course2.CourseId));

            var subject = new EnrollmentCommands(_context);
            var result = await subject.AddOrUpdateStudentsGradeAsync(_course2.CourseId, _student1.StudentId, default);

            var enrollment = result.Select(result => result, error => default);

            Assert.AreEqual(_course2.CourseId, enrollment.CourseId);
            Assert.AreEqual(_student1.StudentId, enrollment.StudentId);
            Assert.AreEqual(default, enrollment.Grade);

            Assert.IsTrue(_context.Enrollment.Any(e => e.StudentId == _student1.StudentId && e.CourseId == _course2.CourseId));
        }

        [Test]
        public async Task AddOrUpdateStudentsGrade_EnrollExistent_UpdatesGrade()
        {
            Assert.IsTrue(_context.Enrollment.Any(e => e.StudentId == _student1.StudentId && e.CourseId == _course3.CourseId && !e.Grade.HasValue));

            var expectedGrade = 12.34m;
            var subject = new EnrollmentCommands(_context);
            var result = await subject.AddOrUpdateStudentsGradeAsync(_course3.CourseId, _student1.StudentId, expectedGrade);

            var enrollment = result.Select(result => result, error => default);

            Assert.AreEqual(_course3.CourseId, enrollment.CourseId);
            Assert.AreEqual(_student1.StudentId, enrollment.StudentId);
            Assert.AreEqual(expectedGrade, enrollment.Grade);

            Assert.AreNotEqual(default, _context.Enrollment.SingleOrDefault(e => e.StudentId == _student1.StudentId && e.CourseId == _course3.CourseId));
        }
    }
}