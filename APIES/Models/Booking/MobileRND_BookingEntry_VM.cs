using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Booking
{
    public class MobileRND_BookingEntry_VM
    {
        public Guid Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public string DateString { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string PaymentName { get; set; }
        public Guid CourierId { get; set; }
        public string Courier { get; set; }
        //public decimal rate { get; set; }
        public string CourierType { get; set; }

        public Guid BrandID { get; set; }
        public Guid ProductID { get; set; }
        public string Brand { get; set; }
        public string Product { get; set; }
        public bool IsApprove { get; set; }

        //public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        //public DateTime? UpdatedOn { get; set; }
        //public Guid LUser { get; set; }
        public bool StatusIsToday { get; set; }
        public List<MobileRND_BookingDetailsEntry_VM> bookingDetails { get; set; }

        //public List<MobileRND_PaymentType_VM> paymentTypeList { get; set; }
        //public List<MobileRND_Brand_VM> brandList { get; set; }
        //public List<MobileRND_Product_VM> productList { get; set; }

        //public List<MobileRND_CourierInformation_VM> courierList { get; set; }

        //public int TotalCN { get; set; }
        //public int TotalQuantity { get; set; }
        //public decimal TotalAmount { get; set; }
    }
}
