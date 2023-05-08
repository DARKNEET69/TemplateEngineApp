namespace TemplateEngineApp
{
    internal static class Logger
    {
        public delegate void LogEventHandler(string message, Type logType);
        public static event LogEventHandler? OnLogged;

        public enum Type
        {
            Info,
            Warning,
            Error,
            Fatal
        }

        public static void Log(string text, Type logType)
        {
            switch (logType)
            {
                case Type.Info:
                    Info(text);
                    break;
                case Type.Warning:
                    Warning(text);
                    break;
                case Type.Error:
                    Error(text);
                    break;
                case Type.Fatal:
                    Fatal(text);
                    break;
            }
        }

        public static void Info(string text)
        {
            OnLogged?.Invoke($"[{DateTime.Now}] [Info] {text}" + Environment.NewLine, Type.Info);
        }

        public static void Warning(string text)
        {
            OnLogged?.Invoke($"[{DateTime.Now}] [Warning] {text}" + Environment.NewLine, Type.Warning);
        }

        public static void Error(string text)
        {
            OnLogged?.Invoke($"[{DateTime.Now}] [Error] {text}" + Environment.NewLine, Type.Error);
        }

        public static void Fatal(string text)
        {
            OnLogged?.Invoke($"[{DateTime.Now}] [Fatal] {text}" + Environment.NewLine, Type.Fatal);
        }
    }
}
