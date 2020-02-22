namespace SistEnferHos.Domain.Helpers.Interfaces
{
    public interface IHandler<T> where T : class
    {
        ICommandResult Handle(T command);
    }
}
