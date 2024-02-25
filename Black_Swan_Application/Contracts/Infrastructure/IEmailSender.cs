using Black_Swan_Application.Models;
using System.Threading.Tasks;

namespace Black_Swan_Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
