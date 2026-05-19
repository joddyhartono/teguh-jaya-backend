namespace TeguhJaya.Api.Queries
{
    public static class CategoryQuery
    {
        public const string qGetCategories = @"
            SELECT id, name, image_base64 AS ImageBase64, description
            FROM categories
            WHERE row_status = 0
        ";

        public const string qGetTotal = @"
            SELECT COUNT(*)
            FROM categories
            WHERE row_status = 0
        ";

        public const string qCreateCategory = @"
            INSERT INTO categories (name, image_base64, description)
            VALUES (@name, @imageBase64, @description)
            RETURNING id, name, image_base64 AS ImageBase64, description
        ";

        public const string qDeleteCategory = @"
            UPDATE categories
            SET row_status = 1
            WHERE id = @id
        ";

        public const string qGetCategory = @"
            SELECT id, name, image_base64 AS ImageBase64, description
            FROM categories
            WHERE id = @id
        ";

        public const string qUpdateCategory = @"
            UPDATE categories
            SET name = @name, image_base64 = @imageBase64, description = @description
            WHERE id = @id
        ";
    }
}