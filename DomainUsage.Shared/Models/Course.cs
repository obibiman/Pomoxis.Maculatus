using DomainUsage.Shared.Base;
using System.Collections.Generic;

namespace DomainUsage.Shared.Models
{
    public class Course : Entitybase
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public string CourseDescription { get; set; }
        public ICollection<StudentCourse> Students { get; set; }
    }
}