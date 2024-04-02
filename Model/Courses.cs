using System.ComponentModel.DataAnnotations;

namespace mohinhcodefirst.Model
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public List<StudentCourses> StudentCourse { get; set; }
    }
}
