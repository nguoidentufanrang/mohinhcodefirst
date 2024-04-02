using System.ComponentModel.DataAnnotations;

namespace mohinhcodefirst.Model
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        public List<StudentCourses> StudentCourse { get; set; }
    }
}
