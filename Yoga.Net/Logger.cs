using System;
using System.Diagnostics;

namespace Yoga.Net
{
    public delegate int LoggerFunc(LogLevel level, string message);

    public static class Logger
    {
        public static readonly LoggerFunc DefaultLogger = (level, message) =>
        {
            Trace.Write(message);
            switch (level)
            {
            case LogLevel.Error:
            case LogLevel.Fatal:
                Console.Error.Write(message);
                break;

            case LogLevel.Warn:
            case LogLevel.Info:
            case LogLevel.Debug:
            case LogLevel.Verbose:
            default:
                Console.Write(message);
                break;
            }

            return 0;
        };

        public static void Log(LogLevel level, string message)
        {
            Log(null, null, level, message);
        }

        public static void Log(YogaNode node, LogLevel level, string message)
        {
            Log(node?.Config, node, level, message);
        }

        public static void Log(YogaConfig config, LogLevel level, string message)
        {
            Log(config, null, level, message);
        }

        static void Log(YogaConfig config, YogaNode node, LogLevel level, string message)
        {
            (node?.Config?.LoggerFunc ?? config?.LoggerFunc ?? DefaultLogger).Invoke(level, message);

            if (level == LogLevel.Fatal)
                Environment.FailFast("Fatal exception");
        }
    };
}
