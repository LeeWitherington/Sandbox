using System;
using System.Collections.Generic;


namespace Samples.Services.FinanceInfo
{
    public interface IFinanceInfoProvider
    {
        StockInfo[] GetQuotes(string symbols);
        string GetQuotesAsHtml(string symbols);
    }
}



