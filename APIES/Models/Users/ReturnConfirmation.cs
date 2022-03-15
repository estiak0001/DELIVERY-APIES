using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Users
{
    public class ReturnConfirmation
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string UserID { get; set; }
        public string status { get; set; }
    }
}
