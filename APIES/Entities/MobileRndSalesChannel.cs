using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_SalesChannel")]
    public partial class MobileRndSalesChannel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ChannelName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
    }
}
