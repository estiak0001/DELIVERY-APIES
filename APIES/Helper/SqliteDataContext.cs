using APIES.Data;
using APIES.Entities;
using AutoMapper.Configuration;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Helper
{
    public class SqliteDataContext : DeliveryDbContext
    {
        //public SqliteDataContext(IConfiguration configuration) : base(configuration) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sqlite database
        //    //options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        //}
    }
}