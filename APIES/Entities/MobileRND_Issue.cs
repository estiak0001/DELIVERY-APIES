using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Entities
{
    [Table(name: "MobileRND_Issue")]
    public class MobileRND_Issue
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string IssueCode { get; set; }

        [Required]
        [StringLength(150)]
        public string CNNumber { get; set; }

        [Required]
        public string Issue { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public string LUser { get; set; }
    }
}
