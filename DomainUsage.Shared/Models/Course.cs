using DomainUsage.Shared.Base;
using System.Collections.Generic;

namespace DomainUsage.Shared.Models
{
    public class Course : Entitybase
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}