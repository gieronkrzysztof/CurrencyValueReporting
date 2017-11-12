using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.External.ExternalObjects
{
    public class NBPCurrencyObject
    {
        [JsonProperty("table")]
        public string table { get; set; }
        [JsonProperty("currency")]
        public string currency { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("rates")]
        public List<NBPCurrencyObjectRates> rates { get; set; }
    }
}
