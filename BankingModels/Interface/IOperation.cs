using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Interface
{
    internal interface IOperation
    {
        int Id  { get; set; }
        string OperationName { get; set; }
    }
}
