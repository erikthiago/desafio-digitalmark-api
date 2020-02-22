using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories.Base;
using System;
using System.Linq;

namespace SistEnferHos.Domain.Repositories
{
    public interface IHospitalRepository : IBaseEntityRepository<Hospital>, IBaseDapperRepository<Hospital>
    {
        IQueryable<IQuery> GetEntitiesByRelationId(Guid hospitalId);
        IQueryable<IQuery> GetAllEntities();
    }
}
