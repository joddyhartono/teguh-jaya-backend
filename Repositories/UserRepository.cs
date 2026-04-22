using Dapper;
using TeguhJaya.Api.Interfaces;
using TeguhJaya.Api.Models;
using TeguhJaya.Api.Queries;

namespace TeguhJaya.Api.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public User? GetUser(string username)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<User>(UserQuery.qGetUser, new {username = username});
            }
        }
    }
}