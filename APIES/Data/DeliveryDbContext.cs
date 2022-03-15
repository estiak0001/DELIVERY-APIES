using APIES.Entities;
using APIES.Helper.ModelHelper;
using APIES.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Data
{
    public partial class DeliveryDbContext : IdentityDbContext<ApplicationUser>
    {
        public DeliveryDbContext()
        {
        }

        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
        : base(options)
        {

        }

        public virtual DbSet<AspNetNavigationMenu> AspNetNavigationMenu { get; set; }
        public virtual DbSet<MobileRndAssignedAsmToDnsm> MobileRndAssignedAsmToDnsm { get; set; }
        public virtual DbSet<MobileRndAssignedCustomerToTso> MobileRndAssignedCustomerToTso { get; set; }
        public virtual DbSet<MobileRndAssignedTsoToAsm> MobileRndAssignedTsoToAsm { get; set; }
        public virtual DbSet<MobileRndBookingDetailsEntry> MobileRndBookingDetailsEntry { get; set; }
        public virtual DbSet<MobileRndBookingEntry> MobileRndBookingEntry { get; set; }
        public virtual DbSet<MobileRndBrand> MobileRndBrand { get; set; }
        public virtual DbSet<MobileRndCourierInformation> MobileRndCourierInformation { get; set; }
        public virtual DbSet<MobileRndCustomerInfo> MobileRndCustomerInfo { get; set; }
        public virtual DbSet<MobileRndEmployeeInformation> MobileRndEmployeeInformation { get; set; }
        public virtual DbSet<MobileRndIndexingEntry> MobileRndIndexingEntry { get; set; }
        public virtual DbSet<MobileRndItems> MobileRndItems { get; set; }
        public virtual DbSet<MobileRndPaymentType> MobileRndPaymentType { get; set; }
        public virtual DbSet<MobileRndProduct> MobileRndProduct { get; set; }
        public virtual DbSet<MobileRndProductModel> MobileRndProductModel { get; set; }
        public virtual DbSet<MobileRndSalesChannel> MobileRndSalesChannel { get; set; }
        public virtual DbSet<MobileRndZone> MobileRndZone { get; set; }
        public DbSet<ReceiveImageCNWise> ReceiveImageCNWise { get; set; }


        public DbSet<MobileRND_Issue> MobileRND_Issue { get; set; }
        public DbSet<IssueImagePath> IssueImagePath { get; set; }
        public DbSet<CustomID> CustomID { get; set; }










        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=ESTIAK45461;Database=DELIVERYSYSTEM;User Id=sa;password=Walton@2021;Trusted_Connection=False;MultipleActiveResultSets=true;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetNavigationMenu>(entity =>
            {
                entity.HasIndex(e => e.ParentMenuId);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<CustomID>()
                .HasNoKey();

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetRoleMenuPermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.NavigationMenuId });

                entity.HasIndex(e => e.NavigationMenuId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<MobileRndAssignedAsmToDnsm>(entity =>
            {
                entity.HasIndex(e => e.EmployeeDnsmid);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndAssignedCustomerToTso>(entity =>
            {
                entity.HasIndex(e => e.EmployeeTsoid);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndAssignedTsoToAsm>(entity =>
            {
                entity.HasIndex(e => e.EmployeeAsmid);

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndBookingDetailsEntry>(entity =>
            {
                entity.HasIndex(e => e.BookingId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourierType).HasDefaultValueSql("(N'')");

                entity.Property(e => e.CustomerNo).HasDefaultValueSql("(N'')");

                entity.Property(e => e.IsApprove).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDelivered).HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<MobileRndBookingEntry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndBrand>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndCourierInformation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndCustomerInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndEmployeeInformation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeType).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<MobileRndIndexingEntry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndItems>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndPaymentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeName).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<MobileRndProduct>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndProductModel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndSalesChannel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MobileRndZone>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
