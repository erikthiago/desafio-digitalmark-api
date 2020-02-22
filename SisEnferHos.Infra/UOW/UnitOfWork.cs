using SistEnferHos.Domain.Helpers;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Infra.Contexts;
using System;

namespace SistEnferHos.Infra.UOW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _entityContext;

        public UnitOfWork(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public CommandResponse Commit()
        {
            try
            {
                var rowsAffected = _entityContext.SaveChanges();
                return new CommandResponse(rowsAffected > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void Dispose()
        {
            _entityContext.Dispose();
        }
    }
}
