using AngularChallengeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public interface IStatusService
    {
        Task<Status> DeleteStatus(int id);
        Task<Status> GetStatus(int id);
        Task<IEnumerable<Status>> GetStatuses();
        Task<Status> PostStatus(Status status);
        Task<Status> PutStatus(int id, Status status);
    }
}