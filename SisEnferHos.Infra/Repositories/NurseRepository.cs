using Dapper;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories;
using SistEnferHos.Infra.Contexts;
using SistEnferHos.Infra.Queries.Nurse;
using SistEnferHos.Infra.Repositories.Base;
using System.Linq;

namespace SistEnferHos.Infra.Repositories
{
    public class NurseRepository : BaseRepository<Nurse>, INurseRepository
    {
        public NurseRepository(EntityContext contextEntity, DapperContext contextDapper) : base(contextEntity, contextDapper)
        {
        }

        public IQueryable<IQuery> GetAllEntities()
        {
            return _contextDapper
              .Connection
              .Query<GetAllNursesQuery>(@"SELECT Id, [EnfNome] AS FullName, [EnfTipoDocumento] AS DocumentType, [CPF] AS CpfNumer, 
                                             [COREN] AS Coren, [EnfDataNascimento] AS BirthDate
                                      FROM [EnfEnfermeiro]",
                                         new { }).AsQueryable();
        }
    }
}
