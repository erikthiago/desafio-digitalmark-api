using SistEnferHos.Domain.Commands.Hospital;
using SistEnferHos.Domain.Helpers.Interfaces;

namespace SistEnferHos.Domain.Handlers.Interface
{
    public interface IHospitalCommandHandlerBase :
        IHandler<CreateHospitalCommand>,
        IHandler<UpdateHospitalCommand>,
        IHandler<DeleteHospitalCommand>
    {
    }
}
