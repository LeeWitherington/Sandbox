using System;


namespace Samples.Services.FinanceInfo
{
    public interface IFinanceInfoRenderer
    {
        string GenerateHtml(StockInfo[] stocks);
    }
}



