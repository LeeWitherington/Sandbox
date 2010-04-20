using System;
using System.Web;
using System.Web.Caching;



namespace Samples.Server
{
    public class CacheProgressMonitor : IProgressMonitor
    {
        // Sets the current status of the task
        public void SetStatus(int taskID, object message)
        {
            HttpContext.Current.Cache.Insert(
                taskID.ToString(),
                message,
                null,
                DateTime.Now.AddMinutes(5),
                Cache.NoSlidingExpiration);
        }

        // Reads the current status of the task
        public string GetStatus(int taskID)
        {
            object o = HttpContext.Current.Cache[taskID.ToString()];
            if (o == null)
                return String.Empty;

            return (string)o;
        }
    }
}
