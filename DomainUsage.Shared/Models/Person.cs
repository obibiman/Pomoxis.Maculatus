using DomainUsage.Shared.Base;
using System;

namespace DomainUsage.Shared.Models
{
    public class Person : Entitybase
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }
}