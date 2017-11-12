using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.BusinessLogic.DataProviders
{
    public interface IDataProvider
    {
        CurrencyValue GetCurrencyValue(CurrencyType currencyType);
        List<CurrencyValue> GetCurrencyValueFromRange(CurrencyType currencyType, DateTime dateFrom, DateTime dateTo);
    }
}
