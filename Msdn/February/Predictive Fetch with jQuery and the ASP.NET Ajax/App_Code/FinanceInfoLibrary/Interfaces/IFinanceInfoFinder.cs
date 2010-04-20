using System;


namespace Samples.Services.FinanceInfo
{
    public interface IFinanceInfoFinder
    {
        string ProviderName { get; }
        StockInfo[] FindQuoteInfo(string symbols);
    }
}



