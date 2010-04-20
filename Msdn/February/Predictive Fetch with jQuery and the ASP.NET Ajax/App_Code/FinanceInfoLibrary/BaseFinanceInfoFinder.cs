using System;
using System.Collections.Generic;



namespace Samples.Services.FinanceInfo
{
    public class BaseFinanceInfoFinder : IFinanceInfoFinder
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public BaseFinanceInfoFinder()
        {
        }

        
        #region IFinanceInfoFinder

        
        /// <summary>
        /// Indicates the name of the financial info provider
        /// </summary>
        public virtual string ProviderName
        {
            get { return "BaseInfoFinder"; }
        }


        /// <summary>
        /// Interface member that gets quote information using a random generator
        /// </summary>
        /// <param name="symbols">Comma-separated string indicating symbols to retrieve</param>
        /// <returns>Array of StockInfo objects</returns>
        StockInfo[] IFinanceInfoFinder.FindQuoteInfo(string symbols)
        {
            return this.FindQuoteInfo(symbols);
        }

        #endregion


        #region Protected Virtuals

        /// <summary>
        /// Gets quotes and related change using a random number generator
        /// </summary>
        /// <param name="symbols">Comma-separated string indicating symbols to retrieve</param>
        /// <returns>NULL</returns>
        protected virtual StockInfo[] FindQuoteInfo(string symbols)
        {
            return null;
        }
        
        #endregion
    }
}