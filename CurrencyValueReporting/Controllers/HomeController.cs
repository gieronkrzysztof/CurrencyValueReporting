using CurrencyValueReporting.Models;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyValueReporting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new CurrencyService();
            var chfData = service.GetAllCurrencyData(CurrencyType.chf);

            return View(chfData);
        }

        public ActionResult CurrencyViewer()
        {
            return View();
        }

        public ActionResult CurrencyPopulator()
        {
            return View();
        }

        public ActionResult GetCurrencyValues(string currencyName)
        {
            var service = new CurrencyService();
            var currencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), currencyName);
            var currencyData = service.GetAllCurrencyData(currencyType);

            return View("CurrencyViewer", currencyData);
        }
        
        public ActionResult RedirectToCurrencyViewerView()
        {
            return RedirectToAction("CurrencyViewer");
        }

        public ActionResult RedirectToCurrencyPopulator()
        {
            return RedirectToAction("CurrencyPopulator");
        }
       
        public ActionResult PopulateDatabase(DateTime dateFrom, DateTime dateTo, string currency)
        {
            var service = new CurrencyService();
            service.PopulateDataSource((CurrencyType)Enum.Parse(typeof(CurrencyType), currency.ToLower()), dateFrom, dateTo);
            return View("Index");
        }
    }
}