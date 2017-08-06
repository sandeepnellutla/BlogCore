using BlogCore.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogCore.Model
{
    public class CategoryContext : DbContext
    {
        private DbSet<Category> _categories;
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
            if (Categories.Count() == 0)
            {
                var results = DataFactory.GetAllCategory();
                Categories.AddRangeAsync(results);
                SaveChanges();
            }
        }

        public bool Add(Category item)
        {

            return false;
        }

        public DbSet<Category> Categories { get; set; }
    }
}
