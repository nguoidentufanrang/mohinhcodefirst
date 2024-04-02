using Microsoft.EntityFrameworkCore;
using mohinhcodefirst.Model;
using System.Reflection.Emit;

namespace mohinhcodefirst.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Students> Student { get; set; }
        public DbSet<Courses> Course { get; set; }
        public DbSet<StudentCourses> StudentCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Cấu hình các quan hệ giữa các bảng
            builder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourse)
                .HasForeignKey(sc => sc.StudentId);

            builder.Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourse)
                .HasForeignKey(sc => sc.CourseId);

        }
    }
}
