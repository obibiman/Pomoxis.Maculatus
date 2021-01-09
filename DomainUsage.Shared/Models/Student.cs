using DomainUsage.Shared.Base;
using System.Collections.Generic;

namespace DomainUsage.Shared.Models
{
    public class Student : Entitybase
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}