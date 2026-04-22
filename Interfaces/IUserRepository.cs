using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Interfaces
{
    public interface IUserRepository
    {
        User? GetUser(string username);
    }
}