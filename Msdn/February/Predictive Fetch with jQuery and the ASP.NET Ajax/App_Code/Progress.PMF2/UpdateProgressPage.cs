using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;


namespace Samples.Server.PMF2
{
    public class InMemoryProgressBasePage : System.Web.UI.Page
    {
        // Defines the PUBLIC, hard-coded event sink for client update requests.
        // The event sink can be implemented either as a page method or 
        // via a local Web service. 
        private static InMemoryProgressMonitor _progMonitor = new InMemoryProgressMonitor();

        [WebMethod]
        public static string GetCurrentStatus(int taskID)
        {
            return _progMonitor.GetStatus(taskID);
        }

        [WebMethod]
        public static void TerminateTask(int taskID)
        {
            _progMonitor.RequestTermination(taskID);
        }
    }
}