using DomainUsage.Shared.Base;
using System;
using System.Collections.Generic;

namespace DomainUsage.Shared.Models
{
    public class Student : Entitybase
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }
    }
}