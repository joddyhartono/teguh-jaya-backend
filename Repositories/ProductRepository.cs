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

        public int GetTotal()
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteScalar<int>(ProductQuery.qGetTotal);
            }
        }

        public Product CreateProduct(Product product)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<Product>(ProductQuery.qCreateProduct, product);
            }
        }

        public int DeleteProduct(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.Execute(ProductQuery.qDeleteProduct, new {id});
            }
        }

        public int UpdateProduct(Product product)
        {
            using (var connection = CreateConnection())
            {
                return connection.Execute(ProductQuery.qUpdateProduct, product);
            }
        }
    }
}