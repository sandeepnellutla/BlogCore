using BlogCore.Model;
using System.Collections.Generic;

namespace BlogCore.DAL
{
    public interface IBlogRepository
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        bool InsertCategory(Category catEntity);
        bool UpdateCategory(Category catEntity);
        bool AddCategory(Category catEntity);
        bool DeleteCategory(Category catEntity);

    }
}
