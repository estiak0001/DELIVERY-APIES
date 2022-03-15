//using APIES.DBEntities;
//using APIES.Models.customerPO;
//using APIES.Models.CustomID;
//using APIES.Models.Transport;
using APIES.Helper.ModelHelper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Helper
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }


        [Obsolete]
        public virtual DbQuery<CustomID> customID { get; set; }

        //[Obsolete]
        //public virtual DbQuery<CustomID> customID { get; set; }
        //[Obsolete]
        //public virtual DbQuery<CPOrderReceiveEntryDetailsIDdto> cPOrderReceiveEntryDetailsIDdto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<InvDefItemCategoryDto> invDefItemCategoryDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<CustomIDDaliveryLocation> customIDDaliveryLocation { get; set; }

        //[Obsolete]
        //public virtual DbQuery<InvDefItemProductGroupDto> InvDefItemProductGroupDto { get; set; }

        //[Obsolete]
        //public virtual DbQuery<InvDefItemBrandDto> InvDefItemBrandDto { get; set; }

        //[Obsolete]
        //public virtual DbQuery<InvDefItemSizeSegmentDto> InvDefItemSizeSegmentDto { get; set; }

        //[Obsolete]
        //public virtual DbQuery<InvDefItemSizeDto> InvDefItemSizeDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<FinalfilteredItem> FinalfilteredItem { get; set; }
        //[Obsolete]
        //public virtual DbQuery<TotalTargetDTO> targetQTY { get; set; }
        //[Obsolete]
        //public virtual DbQuery<CustomIDCoreUserDevice> CustomIDCoreUserDevice { get; set; }
        //[Obsolete]
        //public virtual DbQuery<GetCurrentDiscoutDto> getCurrentDiscoutDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<InvoiceDTO> InvoiceDTOContext { get; set; }
        //[Obsolete]
        //public virtual DbQuery<CustomarForWebApp> CustomarForWebApps { get; set; }
        //[Obsolete]
        //public virtual DbQuery<SalesCustomerDto> SalesCustomerDtos { get; set; }
        //[Obsolete]
        //public virtual DbQuery<LedgerDto> ledgerDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<CustomarInvoiceListDto> CustomarInvoiceListDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<PartialDetailsDto> PartialDetailsDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<DepoWiseChallan> DepoWiseChallan { get; set; }
        //[Obsolete]
        //public virtual DbQuery<TransportTripList> TransportTripList { get; set; }
        //[Obsolete]
        //public virtual DbQuery<TripChallanList> TripChallanList { get; set; }
        //[Obsolete]
        //public virtual DbQuery<RecentOrderDto> RecentOrderDto { get; set; }
        //[Obsolete]
        //public virtual DbQuery<CporderReceiveDetailsDto> CporderReceiveDetailsDto { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<InvDefItemProductGroupDto>(entity =>
        //    {
        //        entity.HasNoKey();
        //    });
        //}


    }
}
