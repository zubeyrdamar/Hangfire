using Hangfire.Web.Services;

namespace Hangfire.Web.BackgroundJobs
{
    public class FireAndForget
    {
        public static void Job_SendEmail(string userId, string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(e => e.Execute(userId, message));
        }
    }
}
