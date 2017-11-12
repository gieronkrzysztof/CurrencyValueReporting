using CurrencyValueReportingApplicationServices.BusinessLogic.DataProcessors;
using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Factories
{
    public class CurrencyProcessorFactory
    {
        public ICurrencyProcessor GetCurrencyProcessor(string CurrencyProcessorType, ICurrencyDataReader dataReader, ICurrencyDataWriter dataWriter)
        {
            switch (CurrencyProcessorType)
            {
                case "Standard":
                    {
                        return new StandardCurrencyProcessor(dataReader, dataWriter);
                    }
                default:
                    throw new NotSupportedException($"{CurrencyProcessorType} is not supported as Currency Processor Type. Please check your config");
            }
        }
    }
}
