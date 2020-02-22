using Flunt.Validations;
using SistEnferHos.Domain.Commands.Base;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers;
using System;

namespace SistEnferHos.Domain.Commands.Nurse
{
    public class CreateNurseCommand : CommandBase
    {
        public string CpfNumber { get; set; }
        public string Coren { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid HospitalId { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
             .Requires()
             .IsNotNullOrEmpty(FullName, "NomeCompleto", "O nome é um campo obrigatório")
             .HasMaxLen(FullName, 255, "NomeCompleto", "O nome deve conter no máximo 255 caracteres")
             .HasMinLen(FullName, 1, "NomeCompleto", "O nome deve conter no mínimo 1 caracter")
             .IsNotNullOrEmpty(Coren, "COREN", "O COREN é um campo obrigatório")
             .HasMaxLen(Coren, 6, "COREN", "O COREN deve conter no máximo 6 caracteres")
             .HasMinLen(Coren, 6, "COREN", "O COREN deve conter no mínimo 6 caracter")
             .AreNotEquals(HospitalId, Guid.Empty, "Id", "Identificação do hospital inválida")
             );

            if (!ValidateDocument())
                AddNotification("CPF", "Número de CPF inválido");
        }

        public override bool ValidateDocument()
        {
            if (DocumentType == EDocumentType.CPF && DocumentValidation.ValidateCPF(CpfNumber))
                return true;

            return false;
        }
    }
}
