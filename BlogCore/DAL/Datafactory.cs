using System.Collections.Generic;
using System.Linq;
using BlogCore.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BlogCore.DAL
{
    public class DataFactory : IBlogRepository
    {
        readonly static string ConnString = @"Data Source=tcp:s15.winhost.com;Initial Catalog=DB_115782_blog;User ID=DB_115782_blog_user;Password=admin123$;Integrated Security=False;";
        public static List<Category> GetAllCategory()
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Category>(SqlQuerieConstants.SqlGetAllCategories).ToList();
            }
        }

        public bool AddCategory(Category catEntity)
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                var dynamicParams = new
                {
                    Name = catEntity.Name,
                    UrlSlug = catEntity.UrlSlug,
                    Description = catEntity.Description
                };

                var returnResult = db.Execute(SqlQuerieConstants.SqlCreateCategory, dynamicParams);
                return returnResult > 0;
            }
        }

        public bool DeleteCategory(Category catEntity)
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                var dynamicParams = new
                {
                    CategoryId = catEntity.CategoryId,
                };

                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Execute(SqlQuerieConstants.SqlDeleteCategory, dynamicParams) > 0;
            }
        }

        public List<Category> GetAllCategories()
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Category>(SqlQuerieConstants.SqlGetAllCategories).ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Category>(SqlQuerieConstants.SqlGetCategoriesById, new { CategoryId = id }).FirstOrDefault();
            }
        }

        public bool UpdateCategory(Category catEntity)
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                var dynamicParams = new
                {
                    CategoryId = catEntity.CategoryId,
                    Name = catEntity.Name,
                    UrlSlug = catEntity.UrlSlug,
                    Description = catEntity.Description
                };

                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Execute(SqlQuerieConstants.SqlUpdateCategory, dynamicParams) > 0;
            }
        }
    }
}
