using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;

namespace MyLeasing.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<Owners> Owners { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
