using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_BookingDetailsEntry")]
    public partial class MobileRndBookingDetailsEntry
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        [Required]
        [Column("CNNumber")]
        [StringLength(150)]
        public string Cnnumber { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ammount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rate { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
        [Required]
        [StringLength(150)]
        public string CourierType { get; set; }
        [Required]
        [StringLength(150)]
        public string CustomerNo { get; set; }
        public DateTime? DeliveredDateTime { get; set; }
        [Required]
        public bool? IsDelivered { get; set; }
        [StringLength(250)]
        public string DoNo { get; set; }
        [Required]
        public bool? IsApprove { get; set; }
        public string ApprovalRemarks { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty(nameof(MobileRndBookingEntry.MobileRndBookingDetailsEntry))]

        public virtual MobileRndBookingEntry Booking { get; set; }
    }
}
