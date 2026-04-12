using Dapper;
using TeguhJaya.Api.Interfaces;
using TeguhJaya.Api.Models;
using TeguhJaya.Api.Queries;

namespace TeguhJaya.Api.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration) /* manggil constructor dari class parent */
        {
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<Product>(ProductQuery.qGetProductsByCategory, new {categoryId = categoryId}).ToList();
            }
        }

        public Product? GetProduct(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<Product>(ProductQuery.qGetProduct, new {id = id});
            }
        }

        public void CreateProduct(Product product)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute(ProductQuery.qCreateProduct, product);
            }
        }

        public void UpdateProduct(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute(ProductQuery.qUpdateProduct, id);
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute(ProductQuery.qDeleteProduct, id);
            }
        }
    }
}