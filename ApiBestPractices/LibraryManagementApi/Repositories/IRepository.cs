namespace LibraryManagementApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
