using CurrencyValueReportingApplicationServices.BusinessLogic.DataProcessors;
using CurrencyValueReportingApplicationServices.BusinessLogic.DataProviders;
using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.External.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrencyValueReportingApplicationServices.BusinessLogic.DataConsumers
{
    public interface IDataConsumer
    {
        void ConsumeData();
    }

    public class DataConsumer : IDataConsumer
    {
        public IDataProvider dataProvider { get; private set; }
        public ICurrencyProcessor currencyProcessor { get; private set; }

        public DataConsumer(IDataProvider dataProvider, ICurrencyProcessor currencyProcessor)
        {
            this.dataProvider = dataProvider;
            this.currencyProcessor = currencyProcessor;
        }

        public void ConsumeData()
        {
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                var currencyData = ConsumeDataForCurrency(currencyType);
                currencyProcessor.ProcessCurrencyDataList(currencyData);
            }
        }

        private List<CurrencyValue> ConsumeDataForCurrency(CurrencyType currency)
        {
            return dataProvider.GetCurrencyValueFromRange(currency, DateTime.Now.AddDays(-2), DateTime.Now);
        }
    }
}
