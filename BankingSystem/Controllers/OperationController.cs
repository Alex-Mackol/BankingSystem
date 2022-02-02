using BankingModels.Interface;
using BankingSystem.EFDatabase.Interface;
using Microsoft.AspNetCore.Mvc;
using BankingSystem.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using BankingModels.Model;

namespace BankingSystem.Controllers
{
    public class OperationController : Controller
    {
        private IDbMethods _db;
        private static ICardInfo _cardInfo;
        private static IOperationDetail _operationDetail;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public OperationController(IDbMethods database, IHttpContextAccessor httpContextAccessor)
        {
            _db = database;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            ViewBag.ControllerName = "Operation";
            _cardInfo = _session.Get<CardInfo>("CardInfo");
            return View();
        }
        public IActionResult Balance()
        {
            _db.AddOperationDetails(_cardInfo, "Баланс");
            return View(_cardInfo);
        }
        public IActionResult WithdrawMoney()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WithdrawMoney(OperationDetail model)
        {
            if (ModelState.IsValid)
            {
                if (IsWithdrawalAvailable(_cardInfo.Sum, model.WithDrawalSum))
                {
                     _cardInfo = _db.RecalculateSumOfCard(_cardInfo, model.WithDrawalSum);
                    _operationDetail= _db.AddOperationDetails(_cardInfo, "Снятие денег", model.WithDrawalSum);
                    _session.Set("CardInfo", _cardInfo);
                    if (_operationDetail != null)
                    {
                        //_session.Set("OperationDetail", _operationDetail);
                        return RedirectToAction("ReceiptInfo", "Operation");
                    }
                }
                else
                {
                    ViewBag.ExeptionMassege = "Сумма снятия больше чем у вас на счету. Попробуйте снова!";
                    return PartialView("ErrorPage");
                }

            }

            return View(model);
        }
        public IActionResult Exit()
        {
            HttpContext.Session.Remove("CardInfo");
            return RedirectToAction("Index","Home");
        }
        public IActionResult ReceiptInfo()
        {
            return View(_operationDetail);
        }

        private bool IsWithdrawalAvailable(double cardSum, double withdrawalSum)
        {
            return (cardSum-withdrawalSum) > 0;
        }
    }
}
