using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_Brand")]
    public partial class MobileRndBrand
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string BrandName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
    }
}
