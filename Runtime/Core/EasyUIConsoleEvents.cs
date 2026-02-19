using System;

namespace GAG.EasyUIConsole
{
    public static class EasyUIConsoleEvents
    {
        public static event Action ConsoleOpened;
        public static void RaiseConsoleOpened() => ConsoleOpened?.Invoke();
        
        public static event Action<string> LogPrintRequested;
        public static void RaiseLogPrintRequested(string message) => LogPrintRequested?.Invoke(message);
        
        public static event Action<string> HighlightPrintRequested;
        public static void RaiseHighlightPrintRequested(string message) => HighlightPrintRequested?.Invoke(message);
        
        public static event Action<string> WarningPrintRequested;
        public static void RaiseWarningPrintRequested(string message) => WarningPrintRequested?.Invoke(message);
        
        public static event Action<string> ErrorPrintRequested;
        public static void RaiseErrorPrintRequested(string message) => ErrorPrintRequested?.Invoke(message);
    }
}