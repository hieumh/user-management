namespace UserManagement.Infrastructures.Log
{
    public interface ILogManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}