using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories.Base;
using System.Linq;

namespace SistEnferHos.Domain.Repositories
{
    public interface INurseRepository : IBaseEntityRepository<Nurse>, IBaseDapperRepository<Nurse>
    {
        IQueryable<IQuery> GetAllEntities();
    }
}
