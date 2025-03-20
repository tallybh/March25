namespace Rabbit_example.Services
{
    public interface IMessanger
    {
        Task SendMessage<T>(T message);
    }
}
