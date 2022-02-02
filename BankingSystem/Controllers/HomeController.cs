using BankingModels.Interface;
using BankingModels.Model;
using BankingSystem.EFDatabase.Interface;
using BankingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace BankingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDbMethods _db;
        private static ICardInfo _cardInfo;
        private static int countTriesOfPin = 0;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public HomeController(ILogger<HomeController> logger, IDbMethods database, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _db = database;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            ViewBag.ControllerName = "Home";
            _cardInfo = null;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CardInfo model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.CardNumber))
            {
                if (await _db.IsCardExistAsync(model.CardNumber))
                {
                    _cardInfo = new CardInfo();
                    _cardInfo = model;
                    return RedirectToAction("CheckPinCode", "Home");
                }
                else
                {
                    ViewBag.ExeptionMassege = "Эта карта заблокирована!";

                    return PartialView("ErrorPage");
                }
            }
            return View(model);
        }
        public IActionResult CheckPinCode()
        {
            return View(_cardInfo);
        }
        [HttpPost]
        public async Task<IActionResult> CheckPinCode(CardInfo model)
        {
            if (ModelState.IsValid)
            {
                if(await _db.IsPinCodeRigth(_cardInfo, model.CardPinCode))
                {
                    _cardInfo = await _db.GetCardByNumAndPin(_cardInfo.CardNumber, model.CardPinCode);
                    if (_cardInfo != null)
                    {
                        //HttpContext.Session.Set()
                        _session.Set("CardInfo", _cardInfo);
                        return RedirectToAction("Index", "Operation");
                    }
                }

                if(++countTriesOfPin >= 4)
                {
                    countTriesOfPin = 0;
                    _db.SetCardBlock(_cardInfo);

                    ViewBag.ExeptionMassege = "Неправильный пинкод. Ваша карта заблокирована!";
                    return PartialView("ErrorPage");
                }
            }

            return View(_cardInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
