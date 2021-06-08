using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Services.Managers.Interfaces
{
    public interface ILoginManager
    {
      Task<LoginResponse> Authenticate(User user);
    }
}