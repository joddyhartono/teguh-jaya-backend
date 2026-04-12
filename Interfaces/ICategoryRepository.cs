using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}