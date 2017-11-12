using CurrencyValueReportingApplicationServices.BusinessLogic.DataProviders;
using CurrencyValueReportingApplicationServices.External.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Factories
{
    public class DataProviderFactory
    {
        public IDataProvider GetDataProvider(string dataProviderType)
        {
            switch (dataProviderType)
            {
                case "NBP":
                {
                        return new NBPApiConsumer();
                }
                default:
                    throw new NotSupportedException($"{dataProviderType} is not supported as Data Provider Type. Please check your config");
            }
        }
    }
}
