namespace ResourceCenter.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Create(TEntity item);
        TEntity? FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
