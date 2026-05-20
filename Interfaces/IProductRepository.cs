using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsByCategory(int categoryId);
        Product? GetProduct(int id);
        int GetTotal();
        Product CreateProduct(Product product);
        int DeleteProduct(int id);

        int UpdateProduct(Product product);
    }
}