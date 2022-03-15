using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Booking
{
    public class MobileRND_BookingDetailsEntry_VM
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public string CNNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Ammount { get; set; }
        public decimal Rate { get; set; }
        public string CourierType { get; set; }
        public string CustomerNameWithNo { get; set; }
        public string CustomerNo { get; set; }
        public Guid CustomerID { get; set; }
        public string Remarks { get; set; }
        public string DoNo { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public Guid LUser { get; set; }
        public string Date { get; set; }
        public string CourierName { get; set; }
        public bool IsDelivered { get; set; }
        public string ApprovalRemarks { get; set; }
        public bool ReceiveButton { get; set; }
    }
}
