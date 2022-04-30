using System;
using System.Collections.Generic;

namespace CompleteExample.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
