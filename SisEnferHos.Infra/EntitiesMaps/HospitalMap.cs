using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Infra.Helpers;

namespace SistEnferHos.Infra.EntitiesMaps
{
    public class HospitalMap : BaseEntityMap<Hospital>
    {
        public HospitalMap() : base("HosHospital")
        {
        }

        public override void Configure(EntityTypeBuilder<Hospital> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.CNPJNumber)
                .IsRequired()
                .HasColumnName("CNPJ")
                .HasColumnType("varchar(18)")
                .IsRequired();

            builder.Property(e => e.Address)
               .IsRequired()
               .HasColumnName("HosEndereco")
               .HasColumnType("varchar(255)")
               .IsRequired();

            builder.HasMany(h =>h.Nurses)
                .WithOne(n => n.Hospital)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
