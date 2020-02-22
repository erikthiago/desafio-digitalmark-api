using Flunt.Validations;
using SistEnferHos.Domain.Helpers;
using System;

namespace SistEnferHos.Domain.Entities
{
    public class Nurse : BaseEntity
    {
        public Nurse()
        {

        }

        public Nurse(string fullName, string CPF, string coren, DateTime? birthDate, EDocumentType documentType) : base(fullName, documentType)
        {
            CpfNumber = CPF;
            Coren = coren;
            BirthDate = birthDate.Value;

            AddNotifications(new Contract()
             .Requires()
             .IsNotNullOrEmpty(Coren, "COREN", "O COREN é um campo obrigatório")
             .HasMaxLen(Coren, 6, "COREN", "O COREN deve conter no máximo 6 caracteres")
             .HasMinLen(Coren, 6, "COREN", "O COREN deve conter no mínimo 6 caracter")
             );

            if (!ValidateDocument())
                AddNotification("CPF", "Número de CPF inválido");
        }

        public string CpfNumber { get; private set; }
        public string Coren { get; private set; }
        public DateTime? BirthDate { get; private set; }

        public Guid HospitalId { get; private set; }
        public Hospital Hospital { get; set; }

        public void SetHospitalId(Guid hospitalId)
        {
            HospitalId = hospitalId;
        }

        public override bool ValidateDocument()
        {
            if (DocumentType == EDocumentType.CPF && DocumentValidation.ValidateCPF(CpfNumber))
                return true;

            return false;
        }
    }
}
