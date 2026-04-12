namespace TeguhJaya.Api.Queries
{
    public static class CategoryQuery
    {
        public const string qGetCategories = @"
            SELECT id, name, image_base64, description
            FROM categories
            WHERE row_status = 0
        ";
    }
}