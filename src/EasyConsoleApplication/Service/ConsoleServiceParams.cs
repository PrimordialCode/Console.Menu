using System;

namespace EasyConsoleApplication.Service
{
    /// <summary>
    /// responsible for capturing, validating and parsing command line parameters
    /// possible command line calls:
    /// app.exe -- will run the console application
    /// app.exe /I -- will install the service with the default informations specified in the ProjectInstaller class
    /// app.exe /I "servicename" -- will install with the specified names (used to install more copies)
    /// app.exe /U -- will uninstall the default service
    /// app.exe /U "servicename" -- will uninstall the specified service
    /// </summary>
    public static class ConsoleServiceParams
    {
        public static string Switch { get; private set; }

        public static string ServiceName { get; private set; }

        public static void ParseParams(string[] args)
        {
            if (args.Length > 0)
            {
                Switch = args[0].ToUpperInvariant();
            }
            if (args.Length == 2)
            {
                ServiceName = args[1];
            }
        }
    }
}
