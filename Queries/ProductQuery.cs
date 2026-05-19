namespace TeguhJaya.Api.Queries
{
    public static class ProductQuery
    {
        public const string qGetProductsByCategory = @"
            SELECT id, name, price, image_base64
            FROM products
            WHERE category_id = @categoryId AND row_status = 0
        ";

        public const string qGetProduct = @"
            SELECT id, name, price, description, image_base64
            FROM products
            WHERE id = @id AND row_status = 0
        ";

        public const string qCreateProduct = @"
            INSERT INTO products (category_id, name, price, description, image_base64)
            VALUES (@categoryId, @name, @price, @description, @imageBase64)
            RETURNING id, category_id as categoryId, name, price, description, image_base64 AS ImageBase64;
        ";

        public const string qUpdateProduct = @"
            UPDATE products
            SET name = @name, price = @price
            WHERE row_status = 0
        ";

        public const string qDeleteProduct = @"
            UPDATE products
            SET row_status = 1
            WHERE name = @name
        ";

        public const string qGetTotal = @"
            SELECT COUNT(*)
            FROM products
            WHERE row_status = 0
        ";
    }
}