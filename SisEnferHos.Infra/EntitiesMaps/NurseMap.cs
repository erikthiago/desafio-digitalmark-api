using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Infra.Helpers;

namespace SistEnferHos.Infra.EntitiesMaps
{
    public class NurseMap : BaseEntityMap<Nurse>
    {
        public NurseMap() : base("EnfEnfermeiro")
        {
        }

        public override void Configure(EntityTypeBuilder<Nurse> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Coren)
                .IsRequired()
                .HasColumnName("COREN")
                .HasColumnType("varchar(6)")
                .IsRequired();

            builder.Property(e => e.CpfNumber)
               .IsRequired()
               .HasColumnName("CPF")
               .HasColumnType("varchar(14)")
               .IsRequired();

            builder.Property(e => e.BirthDate)
              .IsRequired()
              .HasColumnName("EnfDataNascimento")
              .HasColumnType("datetime");



            builder.HasOne(h => h.Hospital)
              .WithMany(n => n.Nurses);
        }
    }
}
