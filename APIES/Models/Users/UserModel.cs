using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Users
{
    public class UserModel
    {
		public string Id { get; set; }
		public string EmployeeID { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Department { get; set; }
		public string Role { get; set; }
        public string AppVersion { get; set; }
    }
}