using DomainUsage.Shared.Base;

namespace DomainUsage.Shared.Models
{
    public class StudentCourse : Entitybase
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}