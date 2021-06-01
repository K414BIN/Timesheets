using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Services.Interfaces
{
    public interface ILoginManager
    {
      Task<LoginResponse> Authenticate(User user);
    }
}