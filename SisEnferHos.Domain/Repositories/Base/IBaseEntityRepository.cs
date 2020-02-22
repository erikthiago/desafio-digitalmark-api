using System;

namespace SistEnferHos.Domain.Repositories.Base
{
    public interface IBaseEntityRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(Guid Id);
        TEntity Update(TEntity obj);
        void Remove(Guid Id);
    }
}
