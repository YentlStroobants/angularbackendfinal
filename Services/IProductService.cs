using AngularChallengeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public interface IProductService
    {
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> PostProduct(Product product);
        Task<Product> PutProduct(int id, Product product);
        Task<IEnumerable<Product>> Search(string name);
    }
}