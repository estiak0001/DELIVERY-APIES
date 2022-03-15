using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Entities
{
    [Table(name: "IssueImagePath")]
    public class IssueImagePath
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(150)]
        public string CNNumber { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public Guid LUser { get; set; }
    }
}