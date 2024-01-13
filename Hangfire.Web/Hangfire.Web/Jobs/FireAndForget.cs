using Hangfire.Web.Services;

namespace Hangfire.Web.BackgroundJobs
{
    public class FireAndForget
    {
        public static void Job_SendEmail(string userId, string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(j => j.Execute(userId, message));
        }
    }
}
