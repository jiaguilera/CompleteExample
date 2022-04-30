using System.Collections.Generic;

namespace CompleteExample.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TimeZone { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
