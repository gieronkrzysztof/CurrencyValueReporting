using CurrencyValueReportingApplicationServices.DAL.Interfaces;
using CurrencyValueReportingApplicationServices.Domain;
using CurrencyValueReportingApplicationServices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyValueReportingApplicationServices.Repositories
{
    public interface ISimpleRepository<T>
    {
        IEnumerable<T> GetAllCurrencyData(CurrencyType currencyType);
        void Add(T item);
        void RemoveAll();
    }

    public class CurrencyRepository : ISimpleRepository<CurrencyValue>
    {
        private ICurrencyDataWriter _currencyDataWriter { get; set; }
        private ICurrencyDataReader _currencyDataReader { get; set; }
        
        public CurrencyRepository(ICurrencyDataWriter currencyDataWriter, ICurrencyDataReader currencyDataReader)
        {
            _currencyDataWriter = currencyDataWriter;
            _currencyDataReader = currencyDataReader;
        }

        public void Add(CurrencyValue item)
        {
            _currencyDataWriter.Write(item);
        }

        public IEnumerable<CurrencyValue> GetAllCurrencyData(CurrencyType currencyType)
        {
            return _currencyDataReader.GetAllCurrencyData(currencyType.ToString());
        }
        
        public void RemoveAll(CurrencyType currencyType)
        {
            _currencyDataWriter.CleanAll(currencyType.ToString());
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
