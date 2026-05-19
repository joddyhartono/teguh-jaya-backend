using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsByCategory(int categoryId);
        Product? GetProduct(int id);
        int GetTotal();
        Product CreateProduct(Product product);
    }
}