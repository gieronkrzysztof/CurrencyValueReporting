using CurrencyValueReportingApplicationServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.DAL.Interfaces
{
    public interface ICurrencyDataReader
    {
        List<CurrencyValue> GetAllCurrencyData(string currency);
        List<CurrencyValue> GetCurrencyDataFromRange(string currency, DateTime dateFrom, DateTime dateTo);
    }
}
