using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Users
{
    public class ConfirmDeviceIDandEmailModel
    {
        public string email { get; set; }
        public string ConfirmationCode { get; set; }
        public string deviceID { get; set; }
    }
}
