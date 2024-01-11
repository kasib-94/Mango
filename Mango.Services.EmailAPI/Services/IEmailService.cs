using Mango.Services.EmailAPI.Message;
using Mango.Services.EmailAPI.Models;

namespace Mango.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cardDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}
