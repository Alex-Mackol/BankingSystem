using BankingModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.EFDatabase.Interface
{
    public interface IDbCRUD
    {
        Task<bool> AddAsync(ICardInfo item);
        //Task<IEnumerable<ICardInfo>> GetAllAsync();
        //Task<bool> UpdateAsync(ICardInfo item);
        //Task<bool> Remove(long id);
        //Task<ICardInfo> GetCardById(long id);
        //Task<bool> IsIdExist(long id);
        //Task<ICardInfo> IsCardlBlocked(string cardNumber);
    } 
}
