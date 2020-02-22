using Flunt.Notifications;
using Flunt.Validations;
using SistEnferHos.Domain.Entities;
using System;

namespace SistEnferHos.Domain.Helpers
{
    public abstract class BaseEntity : Notifiable
    {
        public BaseEntity()
        {

        }

        public BaseEntity(string fullName, EDocumentType documentType)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            DocumentType = documentType;

            AddNotifications(new Contract()
             .Requires()
             .IsNotNullOrEmpty(FullName, "NomeCompleto", "O nome é um campo obrigatório")
             .HasMaxLen(FullName, 255, "NomeCompleto", "O nome deve conter no máximo 255 caracteres")
             .HasMinLen(FullName, 1, "NomeCompleto", "O nome deve conter no mínimo 1 caracter")
             );
        }

        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public EDocumentType DocumentType { get; set; }

        public abstract bool ValidateDocument();
    }
}
