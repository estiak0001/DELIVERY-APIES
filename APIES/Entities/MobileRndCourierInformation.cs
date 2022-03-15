using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_CourierInformation")]
    public partial class MobileRndCourierInformation
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string CourierName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CoverRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal NonCoverRate { get; set; }
        public DateTime RateFixedFromDate { get; set; }
        public DateTime RateFixedToDate { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
    }
}
