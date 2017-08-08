namespace BlogCore.DAL
{
    public static class SqlQuerieConstants
    {
        public const string SqlGetAllCategories = @"select * from Category";
        public const string SqlGetCategoriesById = @"select * from Category where CategoryId=@CategoryId";
        public const string SqlCreateCategory =
                @"insert into Category(name,urlSlug,description) values (@Name,@UrlSlug,@Description)"
            ;
        public const string SqlUpdateCategory =
                @"update Category set name=@Name, urlSlug=@UrlSlug,description=@Description where CategoryId=@CategoryId"
            ;
        public const string SqlDeleteCategory = @"delete from Category where CategoryId=@CategoryId";
    }
}
