using CurrencyValueReportingApplicationServices.BusinessLogic.DataProviders;
using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.External.ExternalObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.External.Consumers
{
    public class NBPApiConsumer : IDataProvider
    {
        public CurrencyValue GetCurrencyValue(CurrencyType currencyType)
        {
            var currencyData = new WebClient().DownloadString(GetDownloadOneDayString(currencyType.ToString()));

            var currencyValue = JsonConvert.DeserializeObject<NBPCurrencyObject>(currencyData);

            return new CurrencyValue
            {
                ReferenceNumber = currencyValue.rates.FirstOrDefault().no,
                Type = (CurrencyType)Enum.Parse(typeof(CurrencyType), currencyValue.code.ToLower()),
                Value = currencyValue.rates.FirstOrDefault().mid,
                Date = DateTime.Parse(currencyValue.rates.FirstOrDefault().effectiveDate)
            };
        }


        public List<CurrencyValue> GetCurrencyValueFromRange(CurrencyType currencyType, DateTime dateFrom, DateTime dateTo)
        {
            var result = new List<CurrencyValue>();
            var currencyData = new WebClient().DownloadString(GetDownloadRangeString(currencyType.ToString(), dateFrom, dateTo));
            var myObjectList = JsonConvert.DeserializeObject<NBPCurrencyObject>(currencyData);

            foreach (var myObject in myObjectList.rates)
            {
                result.Add(ConvertApiObjectToEntity(myObject, currencyType));
            }

            return result;
        }


        private string GetDownloadOneDayString(string currency)
        {
            return $"http://api.nbp.pl/api/exchangerates/rates/a/{currency}/?format=json";
        }

        private string GetDownloadRangeString(string currency, DateTime dateFrom, DateTime dateTo)
        {
            return $"https://api.nbp.pl/api/exchangerates/rates/a/{currency}/{dateFrom.Year}-{GetUserFriendlyDateValue(dateFrom.Month)}-{GetUserFriendlyDateValue(dateFrom.Day)}/{dateTo.Year}-{GetUserFriendlyDateValue(dateTo.Month)}-{GetUserFriendlyDateValue(dateTo.Day)}/?format=json";
        }

        private string GetUserFriendlyDateValue(int value)
        {
            var result = string.Empty;
            result = value <= 9 ? "0" + value.ToString() : value.ToString();
            return result;
        }

        private CurrencyValue ConvertApiObjectToEntity(NBPCurrencyObjectRates nbpCurrencyObjectRates, CurrencyType currencyType)
        {
            return new CurrencyValue
            {
                ReferenceNumber = nbpCurrencyObjectRates.no,
                Type = (CurrencyType)Enum.Parse(typeof(CurrencyType), currencyType.ToString()),
                Value = nbpCurrencyObjectRates.mid,
                Date = DateTime.Parse(nbpCurrencyObjectRates.effectiveDate)
            };
        }
    }
}
