using AngularChallengeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public interface INonFoodService
    {
        Task<NonFood> DeleteNonFood(int id);
        Task<NonFood> GetNonFood(int id);
        Task<IEnumerable<NonFood>> GetNonFoods();
        Task<NonFood> PostNonFood(NonFood nonFood);
        Task<NonFood> PutNonFood(int id, NonFood nonFood);
    }
}