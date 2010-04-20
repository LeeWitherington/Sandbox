using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Configuration;



namespace Samples.Services.FinanceInfo
{
    public class BaseFinanceInfoProvider : IFinanceInfoProvider
    {
 
        /// <summary>
        /// Class constructor
        /// </summary>
        public BaseFinanceInfoProvider()
        {
        }


        #region IFinanceInfoProvider

        /// <summary>
        /// IFinanceInfoProvider.GetQuotes(symbols)
        /// </summary>
        /// <param name="symbols">Comma-separated list of stock symbols to retrieve</param>
        /// <returns>Array of StockInfo</returns>
        public virtual StockInfo[] GetQuotes(string symbols)
        {
            // Get the Finder component from config file (or use the default one)
            IFinanceInfoFinder finder = ResolveFinder();
            if (finder == null)
                throw new NullReferenceException("Invalid Finder component.");

            return finder.FindQuoteInfo(symbols);
        }


        /// <summary>
        /// IFinanceInfoProvider.GetQuotesAsHtml(symbols)
        /// </summary>
        /// <param name="symbols">Comma-separated list of stock symbols to retrieve</param>
        /// <returns>HTML message with response</returns>
        public virtual string GetQuotesAsHtml(string symbols)
        {
            // Get quotes first
            StockInfo[] stocks = GetQuotes(symbols);

            // Get the Renderer component from config file (or use the default one)
            IFinanceInfoRenderer renderer = ResolveRenderer();
            if (renderer == null)
                throw new NullReferenceException("Invalid Renderer component.");

            return renderer.GenerateHtml(stocks);
        }

        #endregion

               
        #region Resolvers

        /// <summary>
        /// Reads the name of the finder component from config (or goes for a default class)
        /// </summary>
        /// <returns>Instance of a class that implements IFinanceInfoFinder</returns>
        protected virtual IFinanceInfoFinder ResolveFinder()
        {
            return new RandomFinanceInfoFinder();
        }


        /// <summary>
        /// Reads the name of the renderer component from config (or goes for a default class)
        /// </summary>
        /// <returns>Instance of a class that implements IFinanceInfoRenderer</returns>
        protected virtual IFinanceInfoRenderer ResolveRenderer()
        {
            string className = ConfigurationManager.AppSettings[FinanceInfoUtils.CONFIG_RENDERER];
            if (String.IsNullOrEmpty(className))
                return new DefaultFinanceInfoRenderer();
            else
            {
                // NB: assuming the assembly is loaded!!! 
                // Use a different overload of CreateInstance for a more general scenario (class+assembly in a string)
                Type t = Type.GetType(className);   
                return Activator.CreateInstance(t) as IFinanceInfoRenderer; 
            }
        }

        #endregion

    }
}