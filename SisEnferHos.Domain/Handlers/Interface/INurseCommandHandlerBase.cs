using SistEnferHos.Domain.Commands.Nurse;
using SistEnferHos.Domain.Helpers.Interfaces;

namespace SistEnferHos.Domain.Handlers.Interface
{
    public interface INurseCommandHandlerBase :
        IHandler<CreateNurseCommand>,
        IHandler<UpdateNurseCommand>,
        IHandler<DeleteNurseCommand>
    {
    }
}
