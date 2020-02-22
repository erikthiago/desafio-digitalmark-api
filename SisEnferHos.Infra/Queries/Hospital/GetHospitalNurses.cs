using SistEnferHos.Domain.Helpers.Interfaces;
using System;

namespace SistEnferHos.Infra.Queries.Hospital
{
    public class GetHospitalNurses : IQuery
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
