using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers.Interfaces;
using System;

namespace SistEnferHos.Infra.Queries.Nurse
{
    public class GetAllNursesQuery : IQuery
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public EDocumentType DocumentType { get; set; }
        public string CpfNumer { get; set; }
        public string Coren { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid HospitalId { get; set; }
    }
}
