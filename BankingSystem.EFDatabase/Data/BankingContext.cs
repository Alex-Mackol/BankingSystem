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

        DbSet<CardInfo> Cards { get; set; }
        DbSet<Operation> Operations { get; set; }
        DbSet<OperationDetail> OperationDetails { get; set; }
    }
}
