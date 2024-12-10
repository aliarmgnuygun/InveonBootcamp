namespace LibraryManagementApi.Services.ExceptionHandlers
{
    public class RedisConnectionException : Exception
    {
        public RedisConnectionException(string message) : base(message)
        {
        }
    }
}
