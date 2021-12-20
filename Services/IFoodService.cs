using AngularChallengeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public interface IFoodService
    {
        Task<Food> DeleteFood(int id);
        Task<Food> GetFood(int id);
        Task<IEnumerable<Food>> GetFoods();
        Task<Food> PostFood(Food food);
        Task<Food> PutFood(int id, Food food);
    }
}