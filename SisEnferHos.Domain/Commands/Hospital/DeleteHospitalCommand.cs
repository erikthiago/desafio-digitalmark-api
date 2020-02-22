using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace SistEnferHos.Domain.Commands.Hospital
{
    public class DeleteHospitalCommand : Notifiable
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
           .Requires()
           .AreNotEquals(Id, Guid.Empty, "Id", "Identificação do hospital inválida")
           );
        }
    }
}
