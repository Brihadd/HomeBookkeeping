using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Models
{
    internal class DatabaseContext : DbContext
    {
       
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<CostCategory> CostCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=T530\\SQLEXPRESS;Initial Catalog=HomeBookkeeping;Trusted_Connection=True");
        }
    }
}
