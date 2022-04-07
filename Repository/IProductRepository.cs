using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Models;

namespace ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Delete(int id);
        Task Update(Product product);
    }
}