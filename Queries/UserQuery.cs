namespace TeguhJaya.Api.Queries
{
    public static class UserQuery
    {
        public const string qGetUser = @"
            SELECT id, username, password
            FROM users
            WHERE username = @username AND row_status = 0
        ";
    }
}