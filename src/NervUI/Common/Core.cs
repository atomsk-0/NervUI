using System.Runtime.InteropServices;
using NervUI.Entities;

namespace NervUI.Common;

public static class Core
{
    internal static bool LogsEnabled = true;
    
    private static bool _initialized = false;
    
    public static OSPlatform Platform;
    
    internal static void Log(string content)
        => Log(content, LogType.INFO, ConsoleColor.White);
        
    internal static void Log(string content, LogType type)
        => Log(content, type, ConsoleColor.White);
    
    internal static void Log(string content, ConsoleColor color)
        => Log(content, LogType.INFO, color);

    internal static void Log(string content, LogType type, ConsoleColor color)
    {
        //Develoepr can disable NervUI logs if he wants by calling Application.DisableLogs() if he wants.
        if (!LogsEnabled) return;
        
        content = $"[{DateTime.Now}]{type}: {content}";
        
        if (type == LogType.DEBUG)
            Console.WriteLine(content, Console.ForegroundColor = color);
        else
            Console.WriteLine(content, Console.ForegroundColor = color);
    }

    internal static void Initialize()
    {
        if (_initialized) return;
        
        Platform = GetOperatingSystem();
        Log($"NervUI running on {Platform}.", LogType.DEBUG);
        _initialized = true;
    }
    
    internal static OSPlatform GetOperatingSystem()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            throw new Exception("This platform isn't supported by NervUI.");

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return OSPlatform.Linux;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return OSPlatform.Windows;

        throw new Exception("Cannot determine platform!");
    }
}