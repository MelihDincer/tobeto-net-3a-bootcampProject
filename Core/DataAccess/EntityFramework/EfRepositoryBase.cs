using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{

    public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>, IRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        //IQueryable, LINQ sorguları oluşturmak için kullanılan bir.NET arayüzüdür.TEntity, metodun sorgulanacağı veri tipidir.
        //Query: Bu, metodun adıdır. Query metodu, IQueryable tipinde bir veri kaynağına LINQ sorguları oluşturmak için kullanılır.
        //Buradaki işleyiş:
        /*_context nesnesinin Set<TEntity>() metodu çağrılır.Bu metot, TEntity tipindeki veriler için bir DbSet nesnesi döndürür.
        DbSet nesnesi, bir IQueryable nesnesine dönüştürülür. Dönüştürülen IQueryable nesnesi, metodun dönüş değeri olarak döndürülür.*/
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            //Burada bir liste alıyoruz. Listedeki tüm verileri istediğimiz durumda predicate null olacaktır. Tüm verileri değil de ilgili sorguya göre verileri de listeleyebiliriz bu durumda null durumu ortadan kalkacaktır.
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            //Burada bir liste alıyoruz. Listedeki tüm verileri istediğimiz durumda predicate null olacaktır. Tüm verileri değil de ilgili sorguya göre verileri de listeleyebiliriz bu durumda null durumu ortadan kalkacaktır.
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return queryable.ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (include != null)
                queryable = include(queryable);
            return queryable.FirstOrDefault(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
