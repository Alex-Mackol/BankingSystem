using BankingModels.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingModels.Model
{
    [Serializable]
    public class CardInfo : ICardInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(19)]
        [RegularExpression(@"\d{4}-\d{4}-\d{4}-\d{4}", ErrorMessage = "Некорректный номер карты")]
        public string CardNumber { get; set; }
        [StringLength(4)]
        [DataType(DataType.Password)]
        public string CardPinCode { get; set; }
        public double Sum { get; set; }
        public bool IsBlocked { get; set; } = false;

    }
}
