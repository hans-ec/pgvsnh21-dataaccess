namespace _02_ServiceLifeTimes.Services
{
    public interface IScopedService
    {
        string GetGuid();
    }


    public class ScopedService : IScopedService
    {
        private string guid;

        public ScopedService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
