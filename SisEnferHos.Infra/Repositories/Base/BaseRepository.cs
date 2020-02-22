using Microsoft.EntityFrameworkCore;
using SistEnferHos.Domain.Repositories.Base;
using SistEnferHos.Infra.Contexts;
using System;

namespace SistEnferHos.Infra.Repositories.Base
{
    public class BaseRepository<T> : IBaseDapperRepository<T>, IBaseEntityRepository<T> where T: class
    {
        public EntityContext _contextEntity;
        public DapperContext _contextDapper;
        protected DbSet<T> DbSet;

        public BaseRepository(EntityContext contextEntity, DapperContext contextDapper)
        {
            _contextEntity = contextEntity;
            _contextDapper = contextDapper;
            DbSet = contextEntity.Set<T>();
        }

        public T Add(T obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public T Update(T obj)
        {
            DbSet.Update(obj);
            return obj;
        }

        public T GetById(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public void Remove(Guid Id)
        {
            DbSet.Remove(DbSet.Find(Id));
        }

        public void Dispose()
        {
            _contextEntity.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
