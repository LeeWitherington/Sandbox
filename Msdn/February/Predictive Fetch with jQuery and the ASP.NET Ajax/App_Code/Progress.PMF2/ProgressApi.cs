using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for the progress-monitor server API 
/// </summary>

namespace Samples.Server.PMF2
{
    public interface IProgressMonitor
    {
        void SetStatus(int taskID, object message);
        string GetStatus(int taskID);
        bool ShouldTerminate(int taskID);
        void RequestTermination(int taskID);
    }

public class InMemoryProgressMonitor : IProgressMonitor 
{
    public const int MAX_TIME_MINUTES = 5;

    // Sets the current status of the task
    public void SetStatus(int taskID, object message)
    {
        HttpContext.Current.Cache.Insert(
            taskID.ToString(), 
            message, 
            null,
            DateTime.Now.AddMinutes(MAX_TIME_MINUTES), 
            Cache.NoSlidingExpiration);
    }

    // Reads the current status of the task
    public string GetStatus(int taskID)
    {
        object o = HttpContext.Current.Cache[taskID.ToString()];
        if (o == null)
            return String.Empty;

        return (string) o;
    }

    // Captures any user feedback (i.e., abort button clicked)
    public bool ShouldTerminate(int taskID)
    {
        string taskResponseID = GetSlotForResponse(taskID);
        object o = HttpContext.Current.Cache[taskResponseID];
        if (o == null)
            return false;

        return true;

    }

    // Sets the task for termination
    public void RequestTermination(int taskID)
    {
        string taskResponseID = GetSlotForResponse(taskID);
        HttpContext.Current.Cache.Insert(
            taskResponseID,
            (object) false,
            null,
            DateTime.Now.AddMinutes(MAX_TIME_MINUTES),
            Cache.NoSlidingExpiration);

        return;

    }

    private string GetSlotForResponse(int taskID)
    {
        return String.Format("{0}-Quit", taskID);
    }
}
}