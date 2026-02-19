namespace GAG.EasyUIConsole
{
    public static class EasyUIC
    {
        public static void Log(string text)
            => Print(text, EasyUIConsoleType.Log);

        public static void Highlight(string text)
            => Print(text, EasyUIConsoleType.Highlight);

        public static void Warning(string text)
            => Print(text, EasyUIConsoleType.Warning);

        public static void Error(string text)
            => Print(text, EasyUIConsoleType.Error);

        public static void Print(string text, EasyUIConsoleType type)
        {
            switch (type)
            {
                case EasyUIConsoleType.Log:
                    EasyUIConsoleEvents.RaiseLogPrintRequested(text);
                    break;
                case EasyUIConsoleType.Highlight:
                    EasyUIConsoleEvents.RaiseHighlightPrintRequested(text);
                    break;
                case EasyUIConsoleType.Warning:
                    EasyUIConsoleEvents.RaiseWarningPrintRequested(text);
                    break;
                case EasyUIConsoleType.Error:
                    EasyUIConsoleEvents.RaiseErrorPrintRequested(text);
                    break;
            }
        }
    }
}