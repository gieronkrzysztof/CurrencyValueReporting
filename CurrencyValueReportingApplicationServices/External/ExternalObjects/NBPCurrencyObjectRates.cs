using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.External.ExternalObjects
{
    public class NBPCurrencyObjectRates
    {
        [JsonProperty("no")]
        public string no { get; set; }
        [JsonProperty("effectiveDate")]
        public string effectiveDate { get; set; }
        [JsonProperty("mid")]
        public decimal mid { get; set; }
    }
}
