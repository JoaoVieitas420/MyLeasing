using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;

namespace MyLeasing.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Owners> Owners { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
