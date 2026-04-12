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
    }
}