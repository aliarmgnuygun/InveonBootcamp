namespace LibraryManagementApi.Services.ExceptionHandlers
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }
    }
}
