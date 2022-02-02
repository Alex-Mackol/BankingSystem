using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Interface
{
    public interface ICardInfo
    {
        int Id { get; set; }
        string CardNumber { get; set; }
        string CardPinCode { get; set; }
        double Sum { get; set; }
        bool IsBlocked { get; set; }

    }
}
