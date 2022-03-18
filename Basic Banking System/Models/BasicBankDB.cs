using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.Models
{
    public class BasicBankDB:DbContext
    {
        public BasicBankDB(DbContextOptions<BasicBankDB> options):base(options)
        {

        }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
