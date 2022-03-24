namespace _02_ServiceLifeTimes.Services
{
    public interface ISingletonService
    {
        string GetGuid();
    }

    public class SingletonService : ISingletonService
    {
        private string guid;

        public SingletonService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
