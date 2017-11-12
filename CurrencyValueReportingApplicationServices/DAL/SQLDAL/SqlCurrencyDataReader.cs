using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyValueReportingApplicationServices.Domain;
using System.Data.Entity;


namespace CurrencyValueReportingApplicationServices.DAL.SQLDAL
{
    public class CurrencyValuesContext : DbContext
    {
        public DbSet<CurrencyValue> CurrencyValues { get; set; }

        public CurrencyValuesContext() : base("name=CurrencyValuesContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CurrencyValuesContext>());
        }
    }

    public class SqlCurrencyDataReader : ICurrencyDataReader
    {
        public List<CurrencyValue> GetAllCurrencyData(string currency)
        {
            var currencyValuesContext = new CurrencyValuesContext();
            return currencyValuesContext.CurrencyValues.Where(x => x.Type.ToString() == currency).ToList();
        }

        public List<CurrencyValue> GetCurrencyDataFromRange(string currency, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }
    }
}
