using System;
using System.Collections.Generic;
using System.Text;


namespace Samples.Services.FinanceInfo
{
    public class BaseFinanceInfoRenderer : IFinanceInfoRenderer
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public BaseFinanceInfoRenderer()
        {
        }


        #region IFinanceInfoRenderer

        /// <summary>
        /// Interface member to render quotes to a HTML table
        /// </summary>
        /// <param name="stocks">Array of the StockInfo objects to render</param>
        /// <returns>HTML message</returns>
        string IFinanceInfoRenderer.GenerateHtml(StockInfo[] stocks)
        {
            return this.GenerateHtml(stocks);
        }

        #endregion


        #region Protected Virtual

        /// <summary>
        /// Render quotes to a styled HTML table
        /// </summary>
        /// <param name="stocks">Array of the StockInfo objects to render</param>
        /// <returns>HTML message</returns>
        protected virtual string GenerateHtml(StockInfo[] stocks)
        {
            return String.Empty;
        }
        
        #endregion
    }
}