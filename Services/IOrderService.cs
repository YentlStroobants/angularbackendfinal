using AngularChallengeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public interface IOrderService
    {
        Task<Order> DeleteOrder(int id);
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> PostOrder(Order order);
        Task<Order> PutOrder(int id, Order order);
    }
}