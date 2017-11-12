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
    public class FileCurrencyDataWriter : ICurrencyDataWriter
    {
        public void CleanAll(string currencyName)
        {
            File.WriteAllText($"{Bootstrapper.FilePath}\\{currencyName}.txt", string.Empty);
        }

        public void Write(CurrencyValue currencyObject)
        {
            WriteInternal(currencyObject);
        }

        private void WriteInternal(CurrencyValue currencyObject)
        {
            using (StreamWriter outputFile = new StreamWriter(File.Open(Bootstrapper.FilePath + currencyObject.Type.ToString() + ".txt", FileMode.Append)))
            {
                outputFile.Write($"{currencyObject.Date.ToShortDateString()};{currencyObject.Type.ToString()};{currencyObject.Value};{currencyObject.ReferenceNumber}\r\n");
            }
        }
    }
}
