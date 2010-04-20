using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace Samples.Services.FinanceInfo
{
    public class YahooFinanceInfoFinder : BaseFinanceInfoFinder
    {
        #region Local variables
        private const string UrlBase = "http://download.finance.yahoo.com/d/quotes.csv?s={0}&f=sl1d1t1c1ohgvj1pp2owern&d=t";
        #endregion


        /// <summary>
        /// Class constructor
        /// </summary>
        public YahooFinanceInfoFinder()
        {
        }

        
        #region Virtuals

        /// <summary>
        /// Indicates the name of the financial info provider
        /// </summary>
        public override string ProviderName
        {
            get { return "Finance Yahoo"; }
        }


        /// <summary>
        /// Gets quotes and related change using the Finance Yahoo web service
        /// </summary>
        /// <param name="symbols">Comma-separated string indicating symbols to retrieve</param>
        /// <returns>Array of StockInfo objects</returns>
        protected override StockInfo[] FindQuoteInfo(string symbols)
        {
            // Set the URL to invoke
            string url = String.Format(UrlBase, symbols);

            // Prepare to work
            string output = String.Empty;
            StreamReader reader = null;

            // Connect and get response
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            // Read the response
            using (reader = new StreamReader(response.GetResponseStream()))
            {
                output = reader.ReadToEnd();
                reader.Close();
            }

            // Parse and return
            return this.ParseResponseToArray(output, this.ProviderName);
        }
        
        #endregion


        #region Helpers

        /// <summary>
        /// Parse the response from Finance Yahoo to an array of custom objects
        /// </summary>
        /// <param name="response">Raw response as received from Yahoo</param>
        /// <param name="providerName">Name to store as the data provider</param>
        /// <returns>Array of StockInfo objects</returns>
        private StockInfo[] ParseResponseToArray(string response, string providerName)
        {
            // Prepare the container
            List<StockInfo> data = new List<StockInfo>();

            // Split response into rows
            string[] rows = response.Split(new string[] { "\n" },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i=0; i < rows.Length; i++)
            {
                string[] tokens = rows[i].Split(',');

                // Extract symbol information
                StockInfo stock = new StockInfo();

                stock.Symbol = RemoveQuotes(tokens[16]);
                stock.Quote = tokens[1];
                stock.Day = RemoveQuotes(tokens[2]);
                stock.Time = RemoveQuotes(tokens[3]);
                stock.Change = RemoveQuotes(tokens[11]);
                stock.ProviderName = providerName;

                data.Add(stock);
            }

            return data.ToArray();
        }


        /// <summary>
        /// Remove leading and trailing double quotes from a text string 
        /// </summary>
        /// <param name="originalText">Text to process</param>
        /// <returns>String without delimiting quotes</returns>
        private string RemoveQuotes(string originalText)
        {
            string temp = originalText.Trim();
            string newText = temp.Substring(1, temp.Length - 2);
            return newText;
        }
        #endregion
    }
}