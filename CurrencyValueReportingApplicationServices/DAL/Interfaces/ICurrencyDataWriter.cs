using CurrencyValueReportingApplicationServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.DAL.Interfaces
{
    public interface ICurrencyDataWriter
    {
        void Write(CurrencyValue currencyObject);
        void CleanAll(string currencyName);
    }
}
