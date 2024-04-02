using System.ComponentModel.DataAnnotations;

namespace mohinhcodefirst.Model
{
    public class StudentCourses
    {
        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}
