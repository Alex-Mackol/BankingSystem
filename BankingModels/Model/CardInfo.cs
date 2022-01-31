using BankingModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Model
{
    public class CardInfo : ICardInfo
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardPinCode { get; set; }
        public int Sum { get; set; }
        public bool IsBlocked { get; set; }
    }
}
