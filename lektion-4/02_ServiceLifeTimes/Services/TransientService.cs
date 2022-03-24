namespace _02_ServiceLifeTimes.Services
{
    public interface ITransientService : IService
    {
    }

    public class TransientService : ITransientService
    {
        private string guid;

        public TransientService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
