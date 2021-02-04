using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Models;

namespace DSEU.Application.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email emailMessage, CancellationToken cancellationToken = default);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
