using Flunt.Validations;
using SistEnferHos.Domain.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SistEnferHos.Domain.Entities
{
    public class Hospital : BaseEntity
    {
        private IList<Nurse> _nurses;

        public Hospital()
        {

        }

        public Hospital(string fullName, string address, string cnpjNumber, EDocumentType documentType) : base(fullName, documentType)
        {
            Address = address;
            CNPJNumber = cnpjNumber;

            AddNotifications(new Contract()
             .Requires()
             .IsNotNullOrEmpty(Address, "Endereco", "O endereço é um campo obrigatório")
             .HasMaxLen(Address, 255, "Endereco", "O endereço deve conter no máximo 255 caracteres")
             .HasMinLen(Address, 30, "Endereco", "O endereço deve conter no mínimo 30 caracter")
             );

            if (!ValidateDocument())
                AddNotification("CNPJ", "Número de CNPJ inválido");
        }

        public string Address { get; private set; }
        public string CNPJNumber { get; private set; }

        public IReadOnlyCollection<Nurse> Nurses { get; set; } = new List<Nurse>();

        public override bool ValidateDocument()
        {
            if (DocumentType == EDocumentType.CNPJ && DocumentValidation.ValidateCNPJ(CNPJNumber))
                return true;

            return false;
        }
    }
}
