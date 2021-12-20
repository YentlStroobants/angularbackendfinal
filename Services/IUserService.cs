using AngularChallengeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string wachtwoord);
        Task<User> DeleteUser(int id);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> PostUser(User user);
        Task<User> PutUser(int id, User user);
        Task<IEnumerable<User>> Search(string name);
    }
}