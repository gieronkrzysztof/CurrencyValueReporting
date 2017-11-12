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
        public HomeController()
        {

        }

        public ActionResult GetCurrencyValues(string currencyName)
        {
            var service = new CurrencyService();
            var currencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), currencyName);

            var currencyData = service.GetAllCurrencyData(currencyType);
            return View("CurrencyViewer", currencyData);
        }
        

        public ActionResult Index()
        {
            var service = new CurrencyService();
            var chfData = service.GetAllCurrencyData(CurrencyType.chf);
            
            return View(chfData);
        }

        public ActionResult RedirectToCurrencyViewerView()
        {
            return RedirectToAction("CurrencyViewer");
        }

        public ActionResult RedirectToCurrencyPopulator()
        {
            return RedirectToAction("CurrencyPopulator");
        }

        public ActionResult CurrencyViewer()
        {
            return View();
        }

        public ActionResult CurrencyPopulator()
        {
            var model = new CurrencyPopulatorViewModel();
            model.AllCurrencies = Enum.GetNames(typeof(CurrencyType)).Select(x => x.ToUpper()).ToList();
            return View(model);
        }

        public ActionResult PopulateDatabase(DateTime dateFrom, DateTime dateTo, string currency)
        {
            var service = new CurrencyService();
            if (service.PopulateDataSource((CurrencyType)Enum.Parse(typeof(CurrencyType), currency.ToLower()), dateFrom, dateTo))
            {

            }
            else
            {

            }
            return View("Index");
        }
    }
}