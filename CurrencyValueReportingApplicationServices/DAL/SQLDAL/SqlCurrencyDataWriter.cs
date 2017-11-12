using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyValueReportingApplicationServices.Domain;

namespace CurrencyValueReportingApplicationServices.DAL.SQLDAL
{
    public class SqlCurrencyDataWriter : ICurrencyDataWriter
    {
        public void CleanAll(string currencyName)
        {
            var currencyValuesContext = new CurrencyValuesContext();
            foreach (var entity in currencyValuesContext.CurrencyValues)
            {
                currencyValuesContext.CurrencyValues.Remove(entity);
            }

            currencyValuesContext.SaveChanges();
        }

        public void Write(CurrencyValue currencyObject)
        {
            var currencyValuesContext = new CurrencyValuesContext();
            currencyValuesContext.CurrencyValues.Add(currencyObject);
            currencyValuesContext.SaveChanges();
        }
    }
}
