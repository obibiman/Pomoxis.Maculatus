using System;

namespace DomainUsage.Shared.Base
{
    public class Entitybase
    {
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}