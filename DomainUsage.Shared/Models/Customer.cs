using DomainUsage.Shared.Base;
using DomainUsage.Shared.Enums;
using System;

namespace DomainUsage.Shared.Models
{
    public class Customer : Entitybase
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string ImmigrationStatus { get; set; }
        public bool? LoyaltyEnrolled { get; set; }
        public WorkStatus EmploymentStatus { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public decimal? Salary { get; set; }
        public int? CreditRating { get; set; }
        //public byte[] Photo { get; set; }
    }
}