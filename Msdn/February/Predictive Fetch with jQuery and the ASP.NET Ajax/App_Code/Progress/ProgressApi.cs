using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for the progress-monitor server API 
/// </summary>

namespace Samples.Server 
{
    public interface IProgressMonitor
    {
        void SetStatus(int taskID, object message);
        string GetStatus(int taskID);
    }
}