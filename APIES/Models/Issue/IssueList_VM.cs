using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Issue
{
    public class IssueList_VM
    {
        public string CNNumber { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string CourierName { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string DONO { get; set; }
    }
}
