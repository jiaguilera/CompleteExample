using CompleteExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    public class TestBase
    {
        protected CompleteExampleDBContext _context;
        protected Course _course1;
        protected Course _course2;
        protected Course _course3;
        protected Course _course4;
        protected Instructor _instructor1;
        protected Instructor _instructor2;
        protected Student _student1;
        protected Student _student2;
        protected Student _student3;
        protected Student _student4;


        [OneTimeTearDown]
        public async Task RunAfterAllTests()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var optionBuilder = new DbContextOptionsBuilder<CompleteExampleDBContext>();
            optionBuilder.UseSqlServer(config.GetConnectionString("SchoolContext"));
            _context = new CompleteExampleDBContext(optionBuilder.Options);

            await SeedTestData();
        }

        private async Task SeedTestData()
        {
            await _context.Database.EnsureCreatedAsync();

            _course1 = new Course { Title = "Course 1", Credits = 2, Description = "Course description 1" };
            _course2 = new Course { Title = "Course 2", Credits = 3, Description = "Course description 2" };
            _course3 = new Course { Title = "Course 3", Credits = 5, Description = "Course description 3" };
            _course4 = new Course { Title = "Course 4", Credits = 8, Description = "Course description 4" };

            _instructor1 = new Instructor { FirstName = "First", LastName = "Instructor", Email = "first@instructors.com", Courses = new List<Course> { _course1, _course3 } };
            _instructor2 = new Instructor { FirstName = "Second", LastName = "Instructor", Email = "second@instructors.com", Courses = new List<Course> { _course2, _course4 } };

            _student1 = new Student { FirstName = "First", LastName = "Student", Email = "first@students.com" };
            _student2 = new Student { FirstName = "Second", LastName = "Student", Email = "second@students.com" };
            _student3 = new Student { FirstName = "Third", LastName = "Student", Email = "third@students.com" };
            _student4 = new Student { FirstName = "Fourth", LastName = "Student", Email = "fourth@students.com" };

            _context.Instructors.AddRange(_instructor1, _instructor2);
            _context.Students.AddRange(_student1, _student2, _student3, _student4);

            await _context.SaveChangesAsync();

            _context.Enrollment.AddRange(
                new Enrollment { CourseId = _course1.CourseId, StudentId = _student1.StudentId, Grade = 80 },
                new Enrollment { CourseId = _course1.CourseId, StudentId = _student2.StudentId, Grade = 40 },
                new Enrollment { CourseId = _course1.CourseId, StudentId = _student3.StudentId, Grade = 50 },
                new Enrollment { CourseId = _course1.CourseId, StudentId = _student4.StudentId, Grade = 90 },
                new Enrollment { CourseId = _course3.CourseId, StudentId = _student1.StudentId },
                new Enrollment { CourseId = _course3.CourseId, StudentId = _student2.StudentId },
                new Enrollment { CourseId = _course3.CourseId, StudentId = _student3.StudentId, Grade = 30 },
                new Enrollment { CourseId = _course3.CourseId, StudentId = _student4.StudentId, Grade = 40 }
                );

            await _context.SaveChangesAsync();
        }
    }
}