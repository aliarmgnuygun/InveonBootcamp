namespace LibraryManagementApi.Services.ExceptionHandlers
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
