using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

                return db.Query<Category>("select * from Category").ToList();
            }
        }

        public bool AddCategory(Category catEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(Category catEntity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            using (IDbConnection db = new SqlConnection(ConnString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Category>("select * from Category").ToList();
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

                return db.Query<Category>($"select * from Category where id={id}").FirstOrDefault();
            }
        }

        public bool InsertCategory(Category catEntity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category catEntity)
        {
            throw new NotImplementedException();
        }
    }
}
