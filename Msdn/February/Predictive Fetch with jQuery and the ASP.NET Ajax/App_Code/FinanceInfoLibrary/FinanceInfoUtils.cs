using System;
using System.ComponentModel;



namespace Samples.Services.FinanceInfo
{
    public static class FinanceInfoUtils
    {
        public const string CONFIG_OFFLINESTOCKSYMBOLS = "FinanceInfo_OfflineStockSymbols";
        public const string CONFIG_ONLINESTOCKSYMBOLS = "FinanceInfo_OnlineStockSymbols";
        public const string CONFIG_RENDERER = "FinanceInfo_Renderer";
        public const string CONFIG_OFFLINEFINDER = "FinanceInfo_OfflineFinder";
        public const string CONFIG_ONLINEFINDER = "FinanceInfo_OnlineFinder";


        /// <summary>
        /// Uses reflection to get a property value indirectly
        /// </summary>
        /// <param name="stock">Container object to get the value from</param>
        /// <param name="propName">Name of the property to retrieve</param>
        /// <returns>Value of the specified property</returns>
        public static object GetPropertyValue(object stock, string propName)
        {
            if (stock == null)
                return null;

            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(stock).Find(propName, true);
            if (descriptor != null)
                return descriptor.GetValue(stock);

            return null;
        }

    }
}
