using System;
using System.Runtime.Serialization;


namespace Samples.Services.FinanceInfo
{
    [DataContract]
    public class StockInfo
    {
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public string Quote { get; set; }
        [DataMember]
        public string Change { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string ProviderName { get; set; }    
    }
}