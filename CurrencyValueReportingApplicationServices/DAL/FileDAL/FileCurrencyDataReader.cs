using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using CurrencyValueReportingApplicationServices.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.DAL.FileDAL
{
    //TODO: Implement config object to make this class independent of bootstrap object
    public class FileCurrencyDataReader : ICurrencyDataReader
    {
        public List<CurrencyValue> GetAllCurrencyData(string currency)
        {
            var fileLines = File.ReadAllLines($"{Bootstrapper.FilePath}{currency}.txt")
                                            .Select(v => GetObjectByLine(v))
                                            .ToList();
            return fileLines;
        }

        public List<CurrencyValue> GetCurrencyDataFromRange(string currency, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        private CurrencyValue GetObjectByLine(string line)
        {
            string[] values = line.Split(';');
            return new CurrencyValue
            {
                Date = Convert.ToDateTime(values[0]),
                Type = (CurrencyType)Enum.Parse(typeof(CurrencyType), values[1]),
                Value = Decimal.Parse(values[2]),
                ReferenceNumber = values[3]
            };
        }
    }
}
