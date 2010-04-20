using System;
using System.Collections.Generic;
using System.Text;


namespace Samples.Services.FinanceInfo
{
    public class DefaultFinanceInfoRenderer : BaseFinanceInfoRenderer
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public DefaultFinanceInfoRenderer()
        {
        }

        #region Protected Virtuals

        /// <summary>
        /// Render quotes to a styled HTML table
        /// </summary>
        /// <param name="stocks">Array of the StockInfo objects to render</param>
        /// <returns>HTML message</returns>
        protected override string GenerateHtml(StockInfo[] stocks)
        {
            string[] headers = { "SYMBOL", "LAST", "CHANGE", "TIME" };
            string[] columns = { "Symbol", "Quote", "Change", "Time" };

            StringBuilder builder = new StringBuilder();
            
            // Pay attention to URLs here
            builder.AppendFormat("<table cellpadding='{0}' cellspacing='{1}' border='{2}' rules='{3}' frame='{4}' style='{5}'>",
                4, 0, 1, "rows", "hsides", "background-image:url(./images/sfondo.gif);");
            builder.AppendFormat("<tr style='background-color:{0};color:{1};'>", "#6B696B", "white");

            // Define header
            for (int i = 0; i < columns.Length; i++)
            {
                builder.AppendFormat("<th>{0}</th>", headers[i]);
            }
            builder.Append("</tr><tr>");

            // Define body 
            for (int i = 0; i < stocks.Length; i++)
            {
                StockInfo stock = stocks[i];
                for (int j = 0; j < columns.Length; j++)
                {
                    string value = (string) FinanceInfoUtils.GetPropertyValue(stock, columns[j]);
                    builder.AppendFormat("<td style='color:{0}' align='{1}'>{2}</td>",
                        (value.StartsWith("+") ? "green" : (value.StartsWith("-") ? "red" : "")),
                        (j == 0 ? "left" : "right"),
                        value);
                }
                builder.Append("</tr><tr>");
            }


            // Define footer 
            builder.AppendFormat("<td style='background-color:#eeeeee;' align='right' colspan='{0}'><small><i>provided by <b>{1}</b></i></small></td>", 
                columns.Length, 
                stocks[0].ProviderName);
            builder.Append("</tr></table>");

            return builder.ToString();
        }
        
        #endregion
    }
}