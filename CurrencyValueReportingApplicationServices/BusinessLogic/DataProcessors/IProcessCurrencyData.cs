using CurrencyValueReportingApplicationServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.BusinessLogic.DataProcessors
{
    public interface ICurrencyProcessor
    {
        int ProcessCurrencyDataList(List<CurrencyValue> CurrencyDataList);
    }
}
