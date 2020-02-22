using Flunt.Validations;
using SistEnferHos.Domain.Commands.Base;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Helpers;

namespace SistEnferHos.Domain.Commands.Hospital
{
    public class UpdateHospitalCommand : CommandBase
    {
        public string Address { get; set; }
        public string CNPJNumber { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(FullName, "NomeCompleto", "O nome é um campo obrigatório")
            .HasMaxLen(FullName, 255, "NomeCompleto", "O nome deve conter no máximo 255 caracteres")
            .HasMinLen(FullName, 1, "NomeCompleto", "O nome deve conter no mínimo 1 caracter")
            .IsNotNullOrEmpty(Address, "Endereco", "O endereço é um campo obrigatório")
            .HasMaxLen(Address, 255, "Endereco", "O endereço deve conter no máximo 255 caracteres")
            .HasMinLen(Address, 30, "Endereco", "O endereço deve conter no mínimo 30 caracter")
            );

            if (!ValidateDocument())
                AddNotification("CNPJ", "Número de CNPJ inválido");
        }

        public override bool ValidateDocument()
        {
            if (DocumentType == EDocumentType.CNPJ && DocumentValidation.ValidateCNPJ(CNPJNumber))
                return true;

            return false;
        }
    }
}
