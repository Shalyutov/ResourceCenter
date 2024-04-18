using Microsoft.EntityFrameworkCore;
using ResourceCenter.Interfaces;

namespace ResourceCenter.Data
{
    public class EntityRepository<TEntity>(DbContext context) : IRepository<TEntity> where TEntity : class
    {
        readonly DbContext dbContext = context;
        readonly DbSet<TEntity> dbSet = context.Set<TEntity>();

        public int Create(TEntity item)
        {
            var entry = dbSet.Add(item);
            dbContext.SaveChanges();
            return (int)entry.CurrentValues["Id"]!;
        }

        public TEntity? FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
            dbContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
