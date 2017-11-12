using CurrencyValueReportingApplicationServices.DAL.FileDAL;
using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using CurrencyValueReportingApplicationServices.DAL.SQLDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Factories
{
    public class CurrencyDataReaderFactory
    {
        public ICurrencyDataReader GetCurrencyDataReader(string currencyDataReader)
        {
            switch (currencyDataReader)
            {
                case "File":
                    {
                        return new FileCurrencyDataReader();
                    }
                case "SQL":
                    {
                        return new SqlCurrencyDataReader();
                    }
                default:
                    throw new NotSupportedException($"{currencyDataReader} is not supported as File Currency Data Reader Type. Please check your config");
            }
        }
    }
}
