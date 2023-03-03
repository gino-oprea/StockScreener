using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.OnlineCompaniesData
{
    public interface IDataAggregator
    {
        public Company GetCompanyCurrentPrice(string TickerSymbol);
        public Company GetCompanyData(string TickerSymbol, bool isCache = false);        
    }
}
