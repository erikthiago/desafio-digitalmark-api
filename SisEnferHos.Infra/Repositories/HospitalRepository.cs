using Dapper;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories;
using SistEnferHos.Infra.Contexts;
using SistEnferHos.Infra.Queries.Hospital;
using SistEnferHos.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistEnferHos.Infra.Repositories
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(EntityContext contextEntity, DapperContext contextDapper) : base(contextEntity, contextDapper)
        {
        }

        public IQueryable<IQuery> GetAllEntities()
        {
            return _contextDapper
               .Connection
               .Query<GetAllHospitalsQuery>(@"SELECT Id, [HosNome] AS FullName, [HosTipoDocumento] AS DocumentType, [CNPJ] AS CNPJNumber, 
                                             [HosEndereco] AS Address
                                      FROM [HosHospital]",
                                          new { }).AsQueryable();
        }

        public IQueryable<IQuery> GetEntitiesByRelationId(Guid hospitalId)
        {
            return _contextDapper
                .Connection
                .Query<GetHospitalNurses>(@"SELECT Id, [EnfNome] AS FullName
                                      FROM [EnfEnfermeiro]
                                      WHERE [HospitalId] = @hospitalId",
                                            new { HospitalId = hospitalId }).AsQueryable();
        }
    }
}
