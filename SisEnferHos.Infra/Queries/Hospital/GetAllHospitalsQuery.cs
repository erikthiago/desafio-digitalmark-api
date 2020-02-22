using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers.Interfaces;
using System;

namespace SistEnferHos.Infra.Queries.Hospital
{
    public class GetAllHospitalsQuery : IQuery
    {
        public Guid Id { get; set ; }
        public string FullName { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string Address { get; set; }
        public string CNPJNumber { get; set; }
    }
}
