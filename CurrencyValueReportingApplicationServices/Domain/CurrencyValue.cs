using CurrencyValueReportingApplicationServices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Domain
{
    public class CurrencyValue
    {
        public int CurrencyValueId {get;set;}
        public CurrencyType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string ReferenceNumber { get; set; }
    }
}