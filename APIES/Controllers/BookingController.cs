using APIES.Models.Booking;
using APIES.Models.Issue;
using APIES.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController
    {
        private readonly IDealerService _dealerService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BookingController(IDealerService dealerService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _dealerService = dealerService ??
                throw new ArgumentNullException(nameof(dealerService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _hostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("OrderListByCustomer/{customerNo}")]
        public List<MobileRND_BookingDetailsEntry_VM> OrderListByCustomer(string customerNo)
        {
            var orderList = _dealerService.OrderList(customerNo);

            return orderList;
        }

        [AllowAnonymous]
        [HttpPost(nameof(BookingReceive))]
        public BookingResponse BookingReceive( List<IFormFile> formFiles,  string cnNumber, string isReceive, string note)
        {
            BookingResponse res = new BookingResponse();
            if(cnNumber == null || cnNumber == "")
            {
                res.IsSuccess = false;
                res.Message = "CN Number not found!";
                res.ReceiveButton = true;
                return res;
            }
            
            if(_dealerService.IsDelivered(cnNumber))
            {
                res.IsSuccess = false;
                res.Message = "This CN (" + cnNumber + ") already received!";
                res.ReceiveButton = false;
                return res;
            }
            else
            {
                try
                {
                    string path = _hostEnvironment.WebRootPath + $@"\ReceiveImage";

                    var tt = Path.Combine(Directory.GetCurrentDirectory());
                    var originalDirectory = Path.Combine("H:\\Curiar Dalivery\\API\\CurierImages\\ReceiveImage");
                    var pathString = Path.Combine(originalDirectory.ToString(), cnNumber);

                    //if (Directory.Exists(pathString))
                    //    Directory.Delete(pathString, true);

                    if (!Directory.Exists(pathString))
                        Directory.CreateDirectory(pathString);

                    var count = formFiles.Count();


                    var noteupdate = _dealerService.UpdateReceiveNote(cnNumber, isReceive, note);
                    if (noteupdate)
                    {
                        if (count > 0)
                        {
                            var imagesave = _dealerService.UploadImage(formFiles, cnNumber, pathString);
                        }

                        res.IsSuccess = true;
                        res.Message = "You received this Challan(" + cnNumber + ") Successfully!";
                        res.ReceiveButton = false;
                        return res;
                    }
                    else
                    {
                        res.IsSuccess = false;
                        res.Message = "Data submit failed! Please try again.";
                        res.ReceiveButton = true;
                        return res;
                    }
                }

                catch (Exception ex)
                {
                    res.IsSuccess = false;
                    res.Message = "Data submit failed! Please try again.";
                    res.ReceiveButton = true;
                    return res;
                }
            }
        }



        [AllowAnonymous]
        [HttpGet("IssuedCNList/{customerNo}")]
        public List<IssueList_VM> IssuedCNList(string customerNo)
        {
            var cnList = _dealerService.IssuedCNList(customerNo);

            return cnList;
        }

        [AllowAnonymous]
        [HttpGet("IssuesList/{cNNumber}")]
        public List<MobileRND_Issue_VM> IssuesList(string cNNumber)
        {
            var issueList = _dealerService.IssueList(cNNumber);

            return issueList;
        }

        [AllowAnonymous]
        [HttpPost(nameof(IssueSubmit))]
        public BookingResponse IssueSubmit(List<IFormFile> formFiles, string cnNumber, string issueDetails, string CustomerNo)
        {
            BookingResponse res = new BookingResponse();
            if (cnNumber == null || cnNumber == "")
            {
                res.IsSuccess = false;
                res.Message = "CN Number not found!";
                res.ReceiveButton = true;
                return res;
            }

            try
            {
                //string path = _hostEnvironment.WebRootPath + $@"\ReceiveImage";

                var tt = Path.Combine(Directory.GetCurrentDirectory());
                var originalDirectory = Path.Combine("H:\\Curiar Dalivery\\API\\CurierImages\\IssuesImage");               
                var pathString = Path.Combine(originalDirectory.ToString(), cnNumber);

                //if (Directory.Exists(pathString))
                //    Directory.Delete(pathString, true);

                if (!Directory.Exists(pathString))
                    Directory.CreateDirectory(pathString);

                var count = formFiles.Count();

                MobileRND_Issue_VM data = new MobileRND_Issue_VM();
                data.CNNumber = cnNumber;
                data.Issue = issueDetails;
                data.LUser = CustomerNo;

                var addIssue = _dealerService.AddIssue(data);
                if (addIssue)
                {
                    if (count > 0)
                    {
                        var imagesave = _dealerService.UploadImage2(formFiles, cnNumber, pathString);
                    }

                    res.IsSuccess = true;
                    res.Message = "Your Issue Submited Successfully!";
                    res.ReceiveButton = false;
                    return res;
                }
                else
                {
                    res.IsSuccess = false;
                    res.Message = "Data submit failed! Please try again.";
                    res.ReceiveButton = true;
                    return res;
                }
            }

            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Data submit failed! Please try again.";
                res.ReceiveButton = true;
                return res;
            }
        }

        //[AllowAnonymous]
        //[HttpPost(nameof(BookingReceive2))]
        //public BookingResponse BookingReceive2([FromBody] BookingParameter bookingParameter)
        //{
        //    BookingResponse res = new BookingResponse();

        //    if (_dealerService.IsDelivered(bookingParameter.CnNumber))
        //    {
        //        res.IsSuccess = false;
        //        res.Message = "This CN (" + bookingParameter.CnNumber + ") already received!";
        //        res.ReceiveButton = false;
        //        return res;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string path = _hostEnvironment.WebRootPath + $@"\ReceiveImage";

        //            var tt = Path.Combine(Directory.GetCurrentDirectory());
        //            var originalDirectory = Path.Combine("H:\\Curiar Dalivery\\API\\CurierReceivedImages");
        //            var pathString = Path.Combine(originalDirectory.ToString(), bookingParameter.CnNumber);

        //            //if (Directory.Exists(pathString))
        //            //    Directory.Delete(pathString, true);

        //            if (!Directory.Exists(pathString))
        //                Directory.CreateDirectory(pathString);

        //            var count = bookingParameter.formFiles.Count();


        //            var noteupdate = _dealerService.UpdateReceiveNote(bookingParameter.CnNumber, bookingParameter.IsReceive, bookingParameter.Note);
        //            if (noteupdate)
        //            {
        //                if (count > 0)
        //                {
        //                    var imagesave = _dealerService.UploadImage(bookingParameter.formFiles, bookingParameter.CnNumber, bookingParameter.IsReceive, bookingParameter.Note, pathString);
        //                }

        //                res.IsSuccess = true;
        //                res.Message = "You received this Challan(" + bookingParameter.CnNumber + ") Successfully!";
        //                res.ReceiveButton = false;
        //                return res;
        //            }
        //            else
        //            {
        //                res.IsSuccess = false;
        //                res.Message = "Data submit failed! Please try again.";
        //                res.ReceiveButton = true;
        //                return res;
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            res.IsSuccess = false;
        //            res.Message = "Data submit failed! Please try again.";
        //            res.ReceiveButton = true;
        //            return res;
        //        }
        //    }
        //}
    }
}
