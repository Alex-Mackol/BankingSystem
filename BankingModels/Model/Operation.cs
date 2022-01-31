using BankingModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Model
{
    public class Operation : IOperation
    {
        public int Id { get; set; }
        public string OperationName { get; set; }
    }
}
