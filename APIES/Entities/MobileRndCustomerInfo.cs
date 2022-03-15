using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_CustomerInfo")]
    public partial class MobileRndCustomerInfo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string CustomerNo { get; set; }
        [Required]
        [StringLength(250)]
        public string CustomerName { get; set; }
        [Column("SalesChannelID")]
        public Guid SalesChannelId { get; set; }
        [Column("ZoneID")]
        public Guid ZoneId { get; set; }
        public Guid Product { get; set; }
        public Guid Brand { get; set; }
        public string Address { get; set; }
        public string DeliveryAddress { get; set; }
        public string PhoneNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
    }
}
