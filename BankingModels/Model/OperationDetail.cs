using BankingModels.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Model
{
    public class OperationDetail : IOperationDetail
    {
        public int Id { get; set; }
        //[ForeignKey("CardInfoKey")]
        public CardInfo Card{ get; set; }
       // [ForeignKey("OperationKey")]
        public Operation Operation { get; set; }
        public DateTime Time { get; set; }
        public int? WithDrawalSum { get; set; }
    }
}
