using Flunt.Notifications;
using SistEnferHos.Domain.Entities;
using System;

namespace SistEnferHos.Domain.Commands.Base
{
    public abstract class CommandBase : Notifiable
    {
        public Guid Id { get;  set; }
        public string FullName { get; set; }
        public EDocumentType DocumentType { get; set; }

        public abstract void Validate();

        public abstract bool ValidateDocument();
    }
}
