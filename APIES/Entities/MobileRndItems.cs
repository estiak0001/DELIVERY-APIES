using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_Items")]
    public partial class MobileRndItems
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public Guid Brand { get; set; }
        [StringLength(150)]
        public string ItemCode { get; set; }
        [StringLength(150)]
        public string ItemName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
    }
}
