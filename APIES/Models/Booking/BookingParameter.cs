using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Models.Booking
{
    public class BookingParameter
    {
        public List<IFormFile> formFiles { get; set; }
        public string CnNumber { get; set; }

        public string IsReceive { get; set; }
        public string Note { get; set; }
    }
}
