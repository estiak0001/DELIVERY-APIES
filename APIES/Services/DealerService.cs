using APIES.Data;
using APIES.Entities;
using APIES.Helper;
using APIES.Models.Booking;
using APIES.Models.Issue;
using APIES.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Services
{
    public class DealerService : IDealerService
    {
		private DeliveryDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly AppSettings _appSettings;
		public DealerService(DeliveryDbContext context, IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager,
							  SignInManager<ApplicationUser> signInManager)
		{
			_context = context;
			_appSettings = appSettings.Value;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		
		public List<MobileRND_BookingDetailsEntry_VM> OrderList(string CustomerNo)
        {
			var items = (from details in _context.MobileRndBookingDetailsEntry.Where(x => x.CustomerNo == CustomerNo && x.IsApprove == true)
						 join booking in _context.MobileRndBookingEntry
							on new { X1 = details.BookingId } equals new { X1 = booking.Id }
							into bo
						 from boo in bo.DefaultIfEmpty()
						 join co in _context.MobileRndCourierInformation
							on new { X1 = boo.CourierId } equals new { X1 = co.Id }
							into coo
						 from cou in coo.DefaultIfEmpty()

						 join cus in _context.MobileRndCustomerInfo
							on new { X1 = details.CustomerNo } equals new { X1 = cus.CustomerNo }
							into rmppr
						 from rmpr in rmppr.DefaultIfEmpty()
						 select new MobileRND_BookingDetailsEntry_VM()
						 {
							 Id = details.Id,
							 CNNumber = details.Cnnumber,
							 Quantity = details.Quantity,
							 Ammount = details.Ammount,
							 Rate = details.Rate,
							 DoNo = details.DoNo,
							 CustomerNameWithNo = rmpr.CustomerName + " (" + details.CustomerNo + ")",
							 CustomerNo = details.CustomerNo,
							 Remarks = details.Remarks,
							 CourierType = details.CourierType,
							 Date = String.Format("{0:MM/dd/yyyy}", boo.BookingDate),
							 CourierName = cou.CourierName,
							 IsDelivered = (bool)details.IsDelivered,
							 ReceiveButton = details.IsDelivered == true ? false : true,
							 ApprovalRemarks = details.ApprovalRemarks == null ? "" : details.ApprovalRemarks,
						 }).ToList();
			return items;
		}

        public bool UploadImage(List<IFormFile> files, string CnNumber, string path)
        {
            try
            {
				path = path ?? string.Empty;
				//var target = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);

				//Directory.CreateDirectory(target);
				int count = 0;
				files.ForEach(file =>
				{
					count++;
					string filename = CnNumber + "_" + count + ".jpg";
					if (file.Length <= 0) return;
					var filePath = Path.Combine(path, filename);
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					AddImagePath(filename, CnNumber);
				});
				return true;
			}
            catch (Exception ex)
            {
				return false;
            }
			
		}

		public bool UploadImage2(List<IFormFile> files, string CnNumber, string path)
		{
			try
			{
				path = path ?? string.Empty;
				//var target = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);

				//Directory.CreateDirectory(target);
				int count = 0;
				files.ForEach(file =>
				{
					count++;
					string filename = CnNumber + "_" + count + ".jpg";
					if (file.Length <= 0) return;
					var filePath = Path.Combine(path, filename);
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					AddImagePath2(filename, CnNumber);
				});
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}

		public bool  UpdateReceiveNote(string CnNumber, string IsReceive, string Note)
        {
			if (CnNumber == null)
			{
				return false;
			}
            else
            {
				bool receive = false;
				if (IsReceive == "true")
                {
					receive = true;
                }

                var data = _context.MobileRndBookingDetailsEntry.Where(x => x.Cnnumber == CnNumber).FirstOrDefault();
				data.ApprovalRemarks = Note;
				data.IsDelivered = receive;
				data.DeliveredDateTime = DateTime.Now;
                _context.MobileRndBookingDetailsEntry.Update(data);
			}
			var result = _context.SaveChanges();
			return result > 0;
		}

        public bool AddImagePath(string path, string CnNumber)
        {
			if (path == null)
			{
				return false;
			}
			else
			{
				_context.ReceiveImageCNWise.Add(new ReceiveImageCNWise()
				{
					ImagePath = path,
					CNNumber = CnNumber,
					CreatedOn = DateTime.Now
				});
			}
			var result = _context.SaveChanges();
			return result > 0;
		}

        public bool IsDelivered(string CnNumber)
        {
			var data = _context.MobileRndBookingDetailsEntry.Where(x => x.Cnnumber == CnNumber).FirstOrDefault();
			if(data.IsDelivered == true)
            {
				return true;
            }
            else
            {
				return false;
            }
		}

        public bool AddIssue(MobileRND_Issue_VM viewmodel)
        {
			if (viewmodel == null)
			{
				return false;
			}
			else
			{
				var code = _context.CustomID.FromSqlRaw("SELECT CONCAT('ISSUE','_','" + viewmodel.CNNumber + "','_', FORMAT(CONVERT(INT, ISNULL(MAX(CAST(RIGHT(IssueCode, 2) as int)), 0)+  1), '00')) as CustomMaxID  From MobileRND_Issue where CNNumber = '" + viewmodel.CNNumber + "'").FirstOrDefault();

				_context.MobileRND_Issue.Add(new MobileRND_Issue()
				{
					IssueCode = code.CustomMaxID.ToString(),
					CNNumber = viewmodel.CNNumber,
					Issue = viewmodel.Issue,
					LUser = viewmodel.LUser,
				});
			}
			var result = _context.SaveChanges();
			return result > 0;
		}

        public List<IssueList_VM> IssuedCNList(string CustomerNo)
        {
            var items = (from issue in _context.MobileRND_Issue
						 join details in _context.MobileRndBookingDetailsEntry
							on new { X1 = issue.CNNumber } equals new { X1 = details.Cnnumber }
							into de
						 from dee in de.DefaultIfEmpty()

						 join booking in _context.MobileRndBookingEntry
							on new { X1 = dee.BookingId } equals new { X1 = booking.Id }
							into bo
						 from boo in bo.DefaultIfEmpty()

						 join co in _context.MobileRndCourierInformation
							on new { X1 = boo.CourierId } equals new { X1 = co.Id }
							into coo
						 from cou in coo.DefaultIfEmpty()

						 join cus in _context.MobileRndCustomerInfo
							on new { X1 = dee.CustomerNo } equals new { X1 = cus.CustomerNo }
							into rmppr
						 from rmpr in rmppr.DefaultIfEmpty()

						 select new IssueList_VM()
						 {
							 CNNumber = issue.CNNumber,
							 Date = boo.BookingDate,
							 DateString = String.Format("{0:MM/dd/yyyy}", boo.BookingDate),
							 CourierName = cou.CourierName,
							 CustomerNo = dee.CustomerNo,
							 DONO = dee.DoNo,
						 }).OrderBy(x=> x.Date).Where(x=> x.CustomerNo == CustomerNo).Distinct().ToList();
			return items;
        }

        public List<MobileRND_Issue_VM> IssueList(string CNNumber)
        {
			var items = (from issue in _context.MobileRND_Issue.Where(x=> x.CNNumber == CNNumber)
						 

						 select new MobileRND_Issue_VM()
						 {
							 IssueCode = issue.IssueCode,
							 CNNumber = issue.CNNumber,
							 Date = issue.CreatedOn,
							 DateString = String.Format("{0:MM/dd/yyyy}", issue.CreatedOn),
							 Issue = issue.Issue,
							 Status = issue.Status == true ? "Completed" : "Pending"
						 }).OrderBy(x => x.Date).ToList();
			return items;
		}

        public bool AddImagePath2(string path, string CnNumber)
        {
			if (path == null)
			{
				return false;
			}
			else
			{
				_context.IssueImagePath.Add(new IssueImagePath()
				{
					ImagePath = path,
					CNNumber = CnNumber,
					CreatedOn = DateTime.Now
				});
			}
			var result = _context.SaveChanges();
			return result > 0;
		}
    }
}
