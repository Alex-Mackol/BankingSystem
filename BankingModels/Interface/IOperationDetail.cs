using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Interface
{
    internal interface IOperationDetail  {
        int Id { get; set; }
        DateTime Time { get; set; }
        int? WithDrawalSum { get; set; }
    }
}
