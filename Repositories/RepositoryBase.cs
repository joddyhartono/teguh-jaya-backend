using System.Data;
using Npgsql;

namespace TeguhJaya.Api.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly IConfiguration _configuration;

        protected RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}