using CCurrencyValueReportingApplicationServices.BusinessLogic.DataConsumers;
using CurrencyValueReportingApplicationServices.BusinessLogic.DataProcessors;
using CurrencyValueReportingApplicationServices.BusinessLogic.DataProviders;
using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using CurrencyValueReportingApplicationServices.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Utils
{
    public class ServiceConfiguration
    {
        public IDataProvider DataProvider { get; set; }
        public ICurrencyProcessor CurrencyProcessor { get; set; }
        public ICurrencyDataReader CurrencyDataReader { get; set; }
        public ICurrencyDataWriter CurrencyDataWriter { get; set; }
    }

    public class InitialConfigurationFactory
    {
        //public DataConsumer DataConsumer { get; private set; }
        public DataProviderFactory DataProviderFactory { get; set; }
        public CurrencyProcessorFactory CurrencyProcessorFactory { get; set; }
        public CurrencyDataReaderFactory CurrencyDataReaderFactory { get; set; }
        public CurrencyDataWriterFactory CurrencyDataWriterFactory { get; set; }

        public InitialConfigurationFactory()
        {
            DataProviderFactory = new DataProviderFactory();
            CurrencyProcessorFactory = new CurrencyProcessorFactory();
            CurrencyDataReaderFactory = new CurrencyDataReaderFactory();
            CurrencyDataWriterFactory = new CurrencyDataWriterFactory();
        }

        public ServiceConfiguration GetInitialConfiguration()
        {
            var currencyDataReader = CurrencyDataReaderFactory.GetCurrencyDataReader(Bootstrapper.CurrencyDataAccessType);
            var currencyDataWriter  = CurrencyDataWriterFactory.GetCurrencyDataWriter(Bootstrapper.CurrencyDataAccessType);

            return new ServiceConfiguration
            {
                CurrencyProcessor = CurrencyProcessorFactory.GetCurrencyProcessor(Bootstrapper.CurrencyProcessorType, currencyDataReader, currencyDataWriter),
                DataProvider = DataProviderFactory.GetDataProvider(Bootstrapper.DataProviderType),
                CurrencyDataReader = currencyDataReader,
                CurrencyDataWriter = currencyDataWriter
            };
        }
    }
}
