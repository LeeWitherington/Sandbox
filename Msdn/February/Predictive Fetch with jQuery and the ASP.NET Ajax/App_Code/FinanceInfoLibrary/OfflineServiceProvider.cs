using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Configuration;



namespace Samples.Services.FinanceInfo
{
    public class OfflineServiceProvider : BaseFinanceInfoProvider
    {

        /// <summary>
        /// Class constructor
        /// </summary>
        public OfflineServiceProvider()
        {
        }

               
        #region Resolvers

        /// <summary>
        /// Reads the name of the finder component from config (or goes for a default class)
        /// </summary>
        /// <returns>Instance of a class that implements IFinanceInfoFinder</returns>
        protected override IFinanceInfoFinder ResolveFinder()
        {
            string className = ConfigurationManager.AppSettings[FinanceInfoUtils.CONFIG_OFFLINEFINDER];
            if (String.IsNullOrEmpty(className))
                return new RandomFinanceInfoFinder();
            else
            {
                // NB: assuming the assembly is loaded!!! 
                // Use a different overload of CreateInstance for a more general scenario (class+assembly in a string)
                Type t = Type.GetType(className);
                return Activator.CreateInstance(t) as IFinanceInfoFinder;
            }
        }

        #endregion

    }
}