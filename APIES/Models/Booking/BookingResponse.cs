using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Booking
{
    public class BookingResponse
    {
        public bool IsSuccess { get; set; }
        public bool ReceiveButton { get; set; }
        public string Message { get; set; }
    }
}
