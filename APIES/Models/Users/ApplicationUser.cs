using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        [Required]
        public string EmployeeID { get; set; }
        public string Department { get; set; }
    }
}
