using System.Threading.Tasks;

namespace Hangfire.Web.Services
{
    public interface IEmailSender
    {
        Task Execute(string userId, string message);
    }
}
