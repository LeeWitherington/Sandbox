using System;
using System.Collections.Generic;
using System.ServiceModel;
 

namespace Samples.Services.FinanceInfo
{
    [ServiceContract(Namespace="Samples.Services", Name="FinanceInfoService")]
    public interface IFinanceInfoService
    {
        [OperationContract]
        StockInfo[] GetQuotes(string symbols, bool isOffline);

        [OperationContract(Name="GetQuotesOffline")]
        StockInfo[] GetQuotes(string symbols);

        [OperationContract(Name="GetQuotesFromConfig")]
        StockInfo[] GetQuotes(bool isOffline);

        [OperationContract(Name = "GetQuotesFromConfigOffline")]
        StockInfo[] GetQuotes();

        [OperationContract(Name = "GetQuotesOfflineAsHtml")]
        string GetQuotesAsHtml(string symbols, bool isOffline);

        [OperationContract(Name = "GetQuotesFromConfigAsHtml")]
        string GetQuotesAsHtml(bool isOffline);

        [OperationContract(Name = "GetQuotesFromConfigAsHtmlEx")]
        string GetQuotesAsHtml(string contextKey);
    }
}



