using System;
using System.Collections.Generic;



namespace Samples.Services.FinanceInfo
{
    public class RandomFinanceInfoFinder : BaseFinanceInfoFinder
    {

        /// <summary>
        /// Class constructor
        /// </summary>
        public RandomFinanceInfoFinder()
        {
        }

        
        #region Virtuals

        /// <summary>
        /// Indicates the name of the financial info provider
        /// </summary>
        public override string ProviderName
        {
            get { return "FictitiousData .NET"; }
        }


        /// <summary>
        /// Gets quotes and related change using a random number generator
        /// </summary>
        /// <param name="symbols">Comma-separated string indicating symbols to retrieve</param>
        /// <returns>Array of StockInfo objects</returns>
        protected override StockInfo[] FindQuoteInfo(string symbols)
        {
            // Get an string array to work with
            string[] elements = symbols.Split(',');

            // Random object
            Random rnd = new Random();

            // Create return value object
            List<StockInfo> data = new List<StockInfo>();


            // Loop through the symbols
            for (int i = 0; i < elements.Length; i++)
            {
                StockInfo stock = new StockInfo();
                stock.ProviderName = this.ProviderName;
                stock.Symbol = elements[i];
                stock.Day = DateTime.Now.ToShortDateString();
                stock.Time = DateTime.Now.ToShortTimeString();

                // Random quote
                double d1 = rnd.NextDouble();
                int mult1 = rnd.Next(1, 100);
                d1 = d1 * mult1;
                stock.Quote = d1.ToString("##0.000");

                // Random change
                double d2 = rnd.NextDouble();
                int mult2 = rnd.Next(1, 10);
                d2 = d2 * mult2;
                string sign = (mult2 % 2 > 0 ? "+" : "-");
                stock.Change = sign + d2.ToString("##0.00") + "%";

                data.Add(stock);
            }

            return data.ToArray();
        }
        
        #endregion
    }
}