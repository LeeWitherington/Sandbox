// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace MVPDemo.Utility
{
    public sealed class CacheSingleton
    {
        private IUnityContainer container = null;
        private static readonly CacheSingleton instance = new CacheSingleton();

        private CacheSingleton() { }

        public static CacheSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        public IUnityContainer GetUnityContainer()
        {
            if (container == null)
            {
                container = new UnityContainer();
                UnityConfigurationSection config = (UnityConfigurationSection)ConfigurationManager.GetSection("unity"); if (config != null) { config.Containers.Default.Configure(container); }
            }
            return container;
        }
    }
}
