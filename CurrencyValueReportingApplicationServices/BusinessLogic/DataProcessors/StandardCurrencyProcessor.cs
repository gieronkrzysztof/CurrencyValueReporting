using CurrencyValueReportingApplicationServices.DAL.FileDAL;
using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using CurrencyValueReportingApplicationServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.BusinessLogic.DataProcessors
{
    public class StandardCurrencyProcessor : ICurrencyProcessor
    {
        private ICurrencyDataReader Reader { get; set; }
        private ICurrencyDataWriter Writer { get; set; }

        public StandardCurrencyProcessor(ICurrencyDataReader reader, ICurrencyDataWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public int ProcessCurrencyDataList(List<CurrencyValue> CurrencyDataList)
        {
            var addedItems = 0;
            var currency = CurrencyDataList.FirstOrDefault().Type;
            var currencyData = Reader.GetAllCurrencyData(currency.ToString());
            foreach (var currencyItem in CurrencyDataList)
            {
                if (!currencyData.Any(x => x.Date == currencyItem.Date))
                {
                    Writer.Write(currencyItem);
                    addedItems++;
                }
            }
            return addedItems;
        }
    }
}
