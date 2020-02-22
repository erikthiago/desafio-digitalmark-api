using SistEnferHos.Domain.Commands.Hospital;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Domain.Extensions;
using SistEnferHos.Domain.Handlers.Base;
using SistEnferHos.Domain.Handlers.Interface;
using SistEnferHos.Domain.Helpers;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Domain.Repositories;

namespace SistEnferHos.Domain.Handlers
{
    public class HospitalCommandHandler : CommandHandlerBase, IHospitalCommandHandlerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IUnitOfWork _uow;

        public HospitalCommandHandler(IHospitalRepository hospitalRepository, IUnitOfWork uow)
        {
            _hospitalRepository = hospitalRepository;
            _uow = uow;
        }

        public ICommandResult Handle(CreateHospitalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.Messages(), command);
            }

            Hospital hospital = new Hospital(command.FullName, command.Address, command.CNPJNumber, command.DocumentType);

            AddNotifications(hospital);

            if (Invalid)
                return new CommandResult(false, hospital.Notifications.Messages(), command);

            _hospitalRepository.Add(hospital);

            _uow.Commit();

            return new CommandResult(true, "Sucesso!", hospital);

        }

        public ICommandResult Handle(UpdateHospitalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.Messages(), command);
            }

            Hospital hospital = new Hospital(command.FullName, command.Address, command.CNPJNumber, command.DocumentType)
            {
                Id = command.Id
            };

            AddNotifications(hospital);

            if (Invalid)
                return new CommandResult(false, hospital.Notifications.Messages(), command);

            _hospitalRepository.Update(hospital);

            _uow.Commit();

            return new CommandResult(true, "Sucesso!", hospital);
        }

        public ICommandResult Handle(DeleteHospitalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.Messages(), command);
            }

            _hospitalRepository.Remove(command.Id);

            _uow.Commit();

            return new CommandResult(true, "Sucesso!", command);
        }
    }
}
