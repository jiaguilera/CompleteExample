using Microsoft.EntityFrameworkCore;

namespace CompleteExample.Entities
{
    public class CompleteExampleDBContext : DbContext
    {

        public CompleteExampleDBContext(DbContextOptions<CompleteExampleDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

    }
}
