using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using Samples.Services.FinanceInfo;



namespace Test
{
    public class DateFinanceInfoRenderer : Samples.Services.FinanceInfo.DefaultFinanceInfoRenderer
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public DateFinanceInfoRenderer()
        {
        }


        #region Overrides

        /// <summary>
        /// Render quotes to a HTML table
        /// </summary>
        /// <param name="stocks">Array of the StockInfo objects to render</param>
        /// <returns>HTML message</returns>
        protected override string GenerateHtml(StockInfo[] stocks)
        {
            DateTime lastUpdate = DateTime.Now;
            string markup = String.Format("<span><b>Last update: </b>{0} &diams; {1}</span>{2}",
                lastUpdate.ToString("ddd, dd MMM yyyy"),
                lastUpdate.ToString("hh:mm:ss"), 
                base.GenerateHtml(stocks));
            
            return markup;
        }

        #endregion

    }
}