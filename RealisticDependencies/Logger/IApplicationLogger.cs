namespace RealisticDependencies.Logger;

public interface IApplicationLogger { 
    public void LogInfo(string message, ConsoleColor color=ConsoleColor.White);

    public void LogDebug(string message);

    public void LogError(string message);
}