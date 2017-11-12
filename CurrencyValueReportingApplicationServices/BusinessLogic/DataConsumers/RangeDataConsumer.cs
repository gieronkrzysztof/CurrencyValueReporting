using CurrencyValueReportingApplicationServices.BusinessLogic.DataProcessors;
using CurrencyValueReportingApplicationServices.BusinessLogic.DataProviders;
using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.External.Consumers;
using CurrencyValueReportingApplicationServices.Utils;
using System;
using System.Collections.Generic;

namespace CurrencyValueReportingApplicationServices.BusinessLogic.DataConsumers
{
    public class RangeDataConsumer
    {
        private IDataProvider dataProvider { get; set; }
        private ICurrencyProcessor processCurrencyData { get; set; }

        public RangeDataConsumer()
        {
            //dataProvider = new NBPApiConsumer();
            //processCurrencyData = new StandardCurrencyProcessor();
        }

        public void InitialDataConsumption()
        {
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                System.IO.File.WriteAllText($"{Bootstrapper.FilePath}{currencyType.ToString()}.txt", string.Empty);
                var currencyData = ConsumeDataForCurrency(currencyType);
                processCurrencyData.ProcessCurrencyDataList(currencyData);
            }
        }

        private List<CurrencyValue> ConsumeDataForCurrency(CurrencyType currency)
        {
            return dataProvider.GetCurrencyValueFromRange(currency, Bootstrapper.DateFrom, DateTime.Now.AddDays(-1));
        }
    }
}
