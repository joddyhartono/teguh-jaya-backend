using Dapper;
using TeguhJaya.Api.Interfaces;
using TeguhJaya.Api.Models;
using TeguhJaya.Api.Queries;

namespace TeguhJaya.Api.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Category> GetCategories()
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<Category>(CategoryQuery.qGetCategories).ToList();
            }
        }

        public int GetTotal()
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteScalar<int>(CategoryQuery.qGetTotal);
            }
        }

        public Category CreateCategory(Category category)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<Category>(CategoryQuery.qCreateCategory, category);
            }
        }

        public int DeleteCategory(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteScalar<int>(CategoryQuery.qDeleteCategory, new {id});
            }
        }

        public Category? GetCategory(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<Category>(CategoryQuery.qGetCategory, new {id});
            }
        }

        public int UpdateCategory(Category category)
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteScalar<int>(CategoryQuery.qUpdateCategory, category);
            }
        }
    }
}