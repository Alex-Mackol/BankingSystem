using BankingModels.Interface;
using BankingModels.Model;
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
    public class BankingBase : IDbMethods
    {
        private BankingContext _context;
        private readonly string _connectionString;
        public BankingBase(IConfiguration config)
        {
            _connectionString = config["Default:ConnectionString"];
        }

        public ICardInfo RecalculateSumOfCard(ICardInfo item, double sum)
        {
            DbContextOptions<BankingContext> option = GetOption();

            using (_context = new BankingContext(option))
            {
                CardInfo card = _context.Cards.FirstOrDefault(u => u.Id == item.Id);
                if (card != null)
                {
                    card.Sum -= sum;
                    _context.Cards.Update(card);
                    _context.SaveChanges();

                    return card;
                }
                return item;
            }
        }

        public async Task<ICardInfo> GetCardByNumAndPin(string cardNumber, string pincode)
        {
            DbContextOptions<BankingContext> option = GetOption();

            using (_context = new BankingContext(option))
            {
                CardInfo card = await _context.Cards.FirstOrDefaultAsync(u => u.CardNumber == cardNumber && u.CardPinCode == pincode);
                if (card != null)
                {
                    card.Sum = Math.Round(card.Sum, 2);
                    return card;
                }

                return null;
            }
        }

        public async Task<bool> IsCardExistAsync(string cardNumber)
        {
            bool isExist = false;
            DbContextOptions<BankingContext> option = GetOption();

            using (_context = new BankingContext(option))
            {
                CardInfo card = await _context.Cards.FirstOrDefaultAsync(u => u.CardNumber == cardNumber && !u.IsBlocked);
                if(card != null)
                {
                    isExist = true;
                }

                return isExist;
            }
        }

        public async Task<bool> IsPinCodeRigth(ICardInfo cardInfo, string pincode)
        {
            bool isRigthPinCode = false;
            DbContextOptions<BankingContext> option = GetOption();

            using (_context = new BankingContext(option))
            {
                CardInfo card = await _context.Cards.FirstOrDefaultAsync(u => u.CardNumber == cardInfo.CardNumber);
                if (card != null)
                {
                    if(Equals(card.CardPinCode, pincode))
                    {
                        isRigthPinCode = true;
                    }
                }

                return isRigthPinCode;
            }
        }
        public IOperationDetail AddOperationDetails(ICardInfo cardInfo, string operationName, double withdrawSum = 0)
        {
            DbContextOptions<BankingContext> option = GetOption();

            using (_context = new BankingContext(option))
            {
                Operation operation = _context.Operations.FirstOrDefault(u => u.OperationName == operationName);
                if (operation != null)
                {
                    OperationDetail operationDetail = new OperationDetail {
                        Card = (CardInfo)cardInfo,
                        Operation = operation, 
                        Time = DateTime.Now,
                        WithDrawalSum = withdrawSum
                    };
                    _context.OperationDetails.Update(operationDetail);
                    _context.SaveChanges();

                    return operationDetail;
                }
                return null;
            }
        }
        public async void SetCardBlock(ICardInfo cardInfo)
        {
            DbContextOptions<BankingContext> option = GetOption();

            using (_context = new BankingContext(option))
            {
                CardInfo cardToBlock = await _context.Cards.FirstOrDefaultAsync(u => u.CardNumber == cardInfo.CardNumber);
                if (cardToBlock != null)
                {
                    cardToBlock.IsBlocked = true;
                    _context.Cards.Update(cardToBlock);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public Task<bool> IsWithdrawalAvailable(ICardInfo cardInfo, double withdrawalSum)
        {
            throw new NotImplementedException();
        }
        private DbContextOptions<BankingContext> GetOption()
        {
            DbContextOptionsBuilder<BankingContext> optionBuilder = new DbContextOptionsBuilder<BankingContext>();
            DbContextOptions<BankingContext> option = optionBuilder.UseSqlServer(_connectionString).Options;

            return option;
        }

      
    }
}
