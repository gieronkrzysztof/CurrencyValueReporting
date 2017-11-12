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
    public class CurrencyDataWriterFactory
    {
        public ICurrencyDataWriter GetCurrencyDataWriter(string currencyDataWriter)
        {
            switch (currencyDataWriter)
            {
                case "File":
                    {
                        return new FileCurrencyDataWriter();
                    }
                case "SQL":
                    {
                        return new SqlCurrencyDataWriter();
                    }
                default:
                    throw new NotSupportedException($"{currencyDataWriter} is not supported as File Currency Data Writer Type. Please check your config");
            }
        }
    }
}
