using BlogCore.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogCore.Model
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
            if (Categories.Count() == 0)
            {
                RefreshContext();
            }
        }

        public void RefreshContext()
        {
            var results = DataFactory.GetAllCategory();
            if (Categories.Any())
            {
                Categories.RemoveRange(Categories);
                SaveChanges();
            }
            Categories.AddRangeAsync(results);
            SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            var result = (new DataFactory()).GetCategory(id);
            return result;
        }

        public bool Add(Category item)
        {
            if ((new DataFactory()).AddCategory(item))
            {
                RefreshContext();
                return true;
            }

            return false;
        }

        public bool Update(Category item)
        {
            var catObject = GetCategoryById(item.CategoryId);
            if (catObject == null)
            {
                return false;
            }
            catObject.CategoryId = item.CategoryId;
            catObject.Description = item.Description;
            catObject.Name = item.Name;
            catObject.UrlSlug = item.UrlSlug;

            if ((new DataFactory()).UpdateCategory(catObject))
            {
                RefreshContext();
            }
            return false;
        }

        public DbSet<Category> Categories { get; set; }
    }
}
