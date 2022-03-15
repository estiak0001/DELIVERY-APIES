using APIES.Entities;
using APIES.Models.Booking;
using APIES.Models.Issue;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Services
{
    public interface IDealerService
    {
        List<MobileRND_BookingDetailsEntry_VM> OrderList(string CustomerNo);
        bool UploadImage(List<IFormFile> files, string CnNumber, string path);
        public bool UpdateReceiveNote(string CnNumber, string IsReceive, string Note);
        public bool AddImagePath(string path, string CnNumber);
        public bool IsDelivered(string CnNumber);

        //Issues
        public bool AddIssue(MobileRND_Issue_VM viewmodel);
        List<IssueList_VM> IssuedCNList(string CustomerNo);
        List<MobileRND_Issue_VM> IssueList(string CNNumber);
        bool UploadImage2(List<IFormFile> files, string CnNumber, string path);
        public bool AddImagePath2(string path, string CnNumber);
    }
}
