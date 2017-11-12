using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyValueReportingApplicationServices.Services;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.DAL.SQLDAL;
using CurrencyValueReportingApplicationServices.Domain;

namespace CurrencyValueTests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void ShouldGetAllTestData()
        {
            var currencyService = new CurrencyService();
            var data = currencyService.GetAllCurrencyData(CurrencyType.chf);
        }

        [TestMethod]
        public void ShouldReadDataFromDatabase()
        {
            var sqlCurrencyDataReader = new SqlCurrencyDataReader();
            sqlCurrencyDataReader.GetAllCurrencyData("chf");
        }

        [TestMethod]
        public void ShouldWriteDataFromDatabase()
        {
            var sqlCurrencyDataReader = new SqlCurrencyDataWriter();
            sqlCurrencyDataReader.Write(new CurrencyValue
            {
                Date = new DateTime(2017, 10, 10),
                ReferenceNumber = "25",
                Type = CurrencyType.chf,
                Value = 100
            });
        }

        [TestMethod]
        public void ShouldPopulateDatabaseWithData()
        {
            var currencyService = new CurrencyService();
            currencyService.PopulateDataSource(CurrencyType.gbp, new DateTime(2017, 1, 1), DateTime.Now);

        }
    }
}
