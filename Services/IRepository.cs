namespace Labb1_Minimal_Api.Services
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Create(T obj);
        public Task<T> Update(T obj);
        public Task<T> Delete(int id);
    }
}
