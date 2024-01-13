using System;
using System.Diagnostics;

namespace Hangfire.Web.Jobs
{
    public class Recurring
    {
        public static void Job_Recurring()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportJob_1", () => RecurringMethod(), Cron.Minutely);
        }

        public static void RecurringMethod()
        {
            Debug.WriteLine("This task is running periodically. Reported at: " + DateTime.Now.ToString());
        }
    }
}
