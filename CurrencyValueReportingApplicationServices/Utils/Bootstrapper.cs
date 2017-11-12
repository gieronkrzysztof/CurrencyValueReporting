using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CurrencyValueReportingApplicationServices.Utils
{
    public static class Bootstrapper
    {
        public static string FilePath { get; set; }
        public static DateTime DateFrom { get; set; }
        public static int RefreshIntervalInSeconds { get; set; }
        public static string DataProviderType {get;set; }
        public static string CurrencyProcessorType { get; set; }
        public static string CurrencyDataAccessType { get; set; }

        public static void ReadConfigFromFile()
        {
            CurrencyDataAccessType = ConfigurationManager.AppSettings["CurrencyDataAccessType"]; 
            FilePath = ConfigurationManager.AppSettings["FilePath"];
            DateFrom = DateTime.Parse(ConfigurationManager.AppSettings["DateFrom"]);
            RefreshIntervalInSeconds = int.Parse(ConfigurationManager.AppSettings["RefreshInterval"]);
            DataProviderType = ConfigurationManager.AppSettings["DataProviderType"];
            CurrencyProcessorType = ConfigurationManager.AppSettings["CurrencyProcessorType"];
        }
    }
}
