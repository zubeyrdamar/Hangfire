using System.Diagnostics;

namespace Hangfire.Web.Jobs
{
    public class Continuation
    {
        public static void Job_Continuation(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine("This task is called after the task with id: " + id));
        }
    }
}
