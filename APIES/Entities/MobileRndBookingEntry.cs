using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_BookingEntry")]
    public partial class MobileRndBookingEntry
    {
        public MobileRndBookingEntry()
        {
            MobileRndBookingDetailsEntry = new HashSet<MobileRndBookingDetailsEntry>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public Guid PaymentTypeId { get; set; }
        public Guid CourierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
        [Column("BrandID")]
        public Guid BrandId { get; set; }
        [Column("ProductID")]
        public Guid ProductId { get; set; }

        [InverseProperty("Booking")]
        public virtual ICollection<MobileRndBookingDetailsEntry> MobileRndBookingDetailsEntry { get; set; }
    }
}
