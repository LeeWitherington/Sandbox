using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Samples.Server
{
    public class ProgressMonitorFactory
    {
        public static IProgressMonitor Create()
        {
            // Inject your actual component here
            return new CacheProgressMonitor();
        }
    }
}