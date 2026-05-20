using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        int GetTotal();
        Category CreateCategory(Category category);
        int DeleteCategory(int id);
        Category? GetCategory(int id);
        int UpdateCategory(Category category);
    }
}