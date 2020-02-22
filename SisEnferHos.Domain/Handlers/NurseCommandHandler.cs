using SistEnferHos.Domain.Commands.Nurse;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Extensions;
using SistEnferHos.Domain.Handlers.Base;
using SistEnferHos.Domain.Handlers.Interface;
using SistEnferHos.Domain.Helpers;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories;
using System;

namespace SistEnferHos.Domain.Handlers
{
    public class NurseCommandHandler : CommandHandlerBase, INurseCommandHandlerBase
    {
        private readonly INurseRepository _nurseRepository;
        private readonly IUnitOfWork _uow;

        public NurseCommandHandler(INurseRepository nurseRepository, IUnitOfWork uow)
        {
            _nurseRepository = nurseRepository;
            _uow = uow;
        }

        public ICommandResult Handle(CreateNurseCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.Messages(), command);
            }

            Nurse nurse = new Nurse(command.FullName, command.CpfNumber, command.Coren, command.BirthDate.Value, command.DocumentType);
            nurse.SetHospitalId(command.HospitalId);

            AddNotifications(nurse);

            if (Invalid)
                return new CommandResult(false, nurse.Notifications.Messages(), command);

            _nurseRepository.Add(nurse);

            _uow.Commit();

            return new CommandResult(true, "Sucesso!", nurse);
        }

        public ICommandResult Handle(UpdateNurseCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.Messages(), command);
            }

            Nurse nurse = new Nurse(command.FullName, command.CpfNumber, command.Coren, command.BirthDate.Value, command.DocumentType)
            {
                Id = command.Id
            };

            nurse.SetHospitalId(command.HospitalId);

            AddNotifications(nurse);

            if (Invalid)
                return new CommandResult(false, nurse.Notifications.Messages(), command);

            _nurseRepository.Update(nurse);

            _uow.Commit();

            return new CommandResult(true, "Sucesso!", nurse);
        }

        public ICommandResult Handle(DeleteNurseCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.Messages(), command);
            }

            _nurseRepository.Remove(command.Id);

            _uow.Commit();

            return new CommandResult(true, "Sucesso!", command);
        }
    }
}
