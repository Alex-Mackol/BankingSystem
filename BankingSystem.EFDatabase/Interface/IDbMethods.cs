using BankingModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.EFDatabase.Interface
{
    public interface IDbMethods
    {
        ICardInfo RecalculateSumOfCard(ICardInfo item, double sum);
        Task<ICardInfo> GetCardByNumAndPin(string cardNumber, string pincode);
        Task<bool> IsCardExistAsync(string cardNumber);
        Task<bool> IsPinCodeRigth(ICardInfo cardInfo, string pincode);
        void SetCardBlock(ICardInfo cardInfo);
        IOperationDetail AddOperationDetails(ICardInfo cardInfo, string operationName, double withdrawSum = 0);
        Task<bool> IsWithdrawalAvailable(ICardInfo cardInfo, double withdrawalSum);
    } 
}
