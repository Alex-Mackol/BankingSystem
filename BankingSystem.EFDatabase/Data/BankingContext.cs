using BankingModels.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.EFDatabase.Data
{
    public class BankingContext: DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> option)
           : base(option)
        {

        }

       public DbSet<CardInfo> Cards { get; set; }
       public DbSet<Operation> Operations { get; set; }
       public DbSet<OperationDetail> OperationDetails { get; set; }
    }
}
