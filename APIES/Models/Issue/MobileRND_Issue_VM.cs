using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Issue
{
    public class MobileRND_Issue_VM
    {
        public Guid Id { get; set; }
        public string IssueCode { get; set; }
        public string CNNumber { get; set; }
        public string Issue { get; set; }
        //public bool Status { get; set; }
        public string Status { get; set; }
        public string DateString { get; set; }
        public DateTime Date { get; set; }
        public string CustomerNo { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public string LUser { get; set; }
    }
}
