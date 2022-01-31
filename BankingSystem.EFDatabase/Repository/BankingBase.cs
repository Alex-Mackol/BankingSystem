using BankingModels.Interface;
using BankingSystem.EFDatabase.Data;
using BankingSystem.EFDatabase.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.EFDatabase.Repository
{
    public class BankingBase : IDbCRUD
    {
        private BankingContext _context;
        private readonly string _connectionString;
        public BankingBase(IConfiguration config)
        {
            _connectionString = config["Default:ConnectionString"];
        }
        public async Task<bool> AddAsync(ICardInfo item)
        {
            bool isAdd = false;
            DbContextOptions<BankingContext> option = GetOption();

            //using (_context = new BankingContext(option))
            //{
            //    if (item == null)
            //    {
            //        return isAdd;
            //    }

                return isAdd;
            //}
        }

        //public Task<IEnumerable<ICardInfo>> GetAllAsync()
        //{
        //}

        //public Task<ICardInfo> GetCardById(long id)
        //{
        //}

        //public Task<ICardInfo> IsCardlBlocked(string cardNumber)
        //{
        //}

        //public Task<bool> IsIdExist(long id)
        //{
        //}

        //public Task<bool> Remove(long id)
        //{
        //}

        //public Task<bool> UpdateAsync(ICardInfo item)
        //{
        //}

        private DbContextOptions<BankingContext> GetOption()
        {
            DbContextOptionsBuilder<BankingContext> optionBuilder = new DbContextOptionsBuilder<BankingContext>();
            DbContextOptions<BankingContext> option = optionBuilder.UseSqlServer(_connectionString).Options;

            return option;
        }
    }
}
