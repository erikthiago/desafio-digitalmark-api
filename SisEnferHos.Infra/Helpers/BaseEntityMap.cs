using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistEnferHos.Domain.Helpers;

namespace SistEnferHos.Infra.Helpers
{
    public abstract class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        private readonly string _table;

        public BaseEntityMap(string table)
        {
            _table = table;
        }

        // Configuração do que é comum
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            var abbr = "";

            if (_table == "HosHospital")
                abbr = "Hos";

            if (_table == "EnfEnfermeiro")
                abbr = "Enf";

            builder.ToTable(_table);

            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.DocumentType)
            .IsRequired()
            .HasColumnName($"{abbr}TipoDocumento")
            .HasColumnType("int");

            builder.Property(e => e.FullName)
            .HasColumnName($"{abbr}Nome")
            .HasColumnType("varchar(255)")
            .IsRequired();


            //Ignorar a herança do Flunt
            builder.Ignore(o => o.Invalid);
            builder.Ignore(o => o.Valid);
        }
    }
}
