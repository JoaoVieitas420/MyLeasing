﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Controllers;

namespace MyLeasing.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<Owners> Owners { get; set; }

        public DbSet<Lessee> Lessees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<MyLeasing.Web.Data.Entities.Lessee> Lessee { get; set; }
    }
}
