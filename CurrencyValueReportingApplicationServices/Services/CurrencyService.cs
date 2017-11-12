using CCurrencyValueReportingApplicationServices.BusinessLogic.DataConsumers;
using CurrencyValueReportingApplicationServices.BusinessLogic.DataConsumers;
using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.Factories;
using CurrencyValueReportingApplicationServices.Repositories;
using CurrencyValueReportingApplicationServices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Services
{
    public interface ICurrencyService
    {
        List<CurrencyValue> GetAllCurrencyData(CurrencyType currencyType);
        bool PopulateDataSource(CurrencyType currencyType, DateTime dateFrom, DateTime dateTo);
    }

    public class CurrencyService : ICurrencyService
    {
        public ServiceConfiguration ServiceConfiguration { get; private set; }
        public CurrencyRepository CurrencyRepository { get; set; }

        public CurrencyService()
        {
            Bootstrapper.ReadConfigFromFile();
            InitialConfigurationFactory InitialConfigurationFactory  = new InitialConfigurationFactory();
            ServiceConfiguration = InitialConfigurationFactory.GetInitialConfiguration();
            CurrencyRepository = new CurrencyRepository(ServiceConfiguration.CurrencyDataWriter, ServiceConfiguration.CurrencyDataReader);
        }

        public List<CurrencyValue> GetAllCurrencyData(CurrencyType currencyType)
        {
            List<CurrencyValue> result;

            try
            {
                result = CurrencyRepository.GetAllCurrencyData(currencyType).ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Error while collecting value data for currency {currencyType.ToString()}", e);
            }

            return result;
        }

        public bool PopulateDataSource(CurrencyType currencyType, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var currencyDataFromRange = ServiceConfiguration.DataProvider.GetCurrencyValueFromRange(currencyType, dateFrom, dateTo);
                CurrencyRepository.RemoveAll(currencyType);
                foreach (var currencyItem in currencyDataFromRange)
                {
                    CurrencyRepository.Add(currencyItem);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
