using SendGrid;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string emailSubject, string message);
        Task<Response> Execute(string apiKey, string subject, string message, string email);
    }
}
