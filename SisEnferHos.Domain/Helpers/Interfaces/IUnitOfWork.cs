using System;

namespace SistEnferHos.Domain.Helpers.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
