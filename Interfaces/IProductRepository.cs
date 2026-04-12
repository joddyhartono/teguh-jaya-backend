using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsByCategory(int categoryId);
        Product? GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(int id);
        void DeleteProduct(int id);
    }
}