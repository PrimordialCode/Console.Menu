using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
#if NET45
using System.Configuration.Install;
#endif

namespace EasyConsoleApplication.Service
{
    /// <summary>
	/// self installer
	/// http://stackoverflow.com/questions/9021075/how-to-create-an-installer-for-a-net-windows-service-using-visual-studio
	/// http://stackoverflow.com/questions/6152017/c-sharp-installutil-managedinstallerclass-why-are-key-value-pairs-not-pass-into
	/// http://stackoverflow.com/questions/4144019/self-install-windows-service-in-net-c-sharp
	/// also look at this
	/// https://stackoverflow.com/questions/7764088/net-console-application-as-windows-service
	/// 
	/// possible command line calls:
	/// app.exe -- will run the console application
	/// app.exe /I -- will install the service with the default informations specified in the ProjectInstaller class
	/// app.exe /I "servicename" -- will install with the specified names (used to install more copies)
	/// app.exe /U -- will uninstall the default service
	/// app.exe /U "servicename" -- will uninstall the specified service
	/// </summary>
	public abstract class ConsoleService : ServiceBase
    {
        private static HandlerRoutine _consoleCloseHandle;

        protected bool IsServiceMode
        {
            get { return _consoleCloseHandle == null; }
        }

        protected virtual void DisplayConsoleApplication()
        {
            // wait here for a key to be pressed
            Trace.WriteLine(ServiceName + " running... Press any key to stop");
            Trace.WriteLine("");
            Console.ReadKey();
        }

        public void RunConsole(string[] args)
        {
            // set a handler to incercept Ctrl+C Crtl+Break or closing the console app
            _consoleCloseHandle = new HandlerRoutine(ConsoleCtrlCheck);
            SetConsoleCtrlHandler(_consoleCloseHandle, true);

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            OnStart(args);

            DisplayConsoleApplication();

            // clean exit
            OnStop();
        }

        public static void Run<TService>(string[] args) where TService : ConsoleService, new()
        {
            ConsoleServiceParams.ParseParams(args);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // double check this: in dotnet core might always return 'true'...
            if (Environment.UserInteractive)
            {
                string option = args.Length > 0 ? args[0].ToUpperInvariant() : String.Empty;
                switch (option)
                {
                    case "-I":
                    case "/I":
                        {
#if NETSTANDARD2_0
                            throw new NotSupportedException("Use 'sc' to install and start the service");
#endif
#if NET45
                            try
                            {
                                /* This is quite old thread, but maybe someone still could use the answer like I could have if it was here earlier :). Only parameters before location are being passed into the context for the installer. Try this:

                                    args = new[] { "/ServiceName=WinService1", Assembly.GetExecutingAssembly().Location };
                                    ManagedInstallerClass.InstallHelper(args);
                                 * 
                                 *  se non passo nulla usa le informazioni presenti nella classe 'projectinstaller'
                                 */
                                //if (string.IsNullOrEmpty(ConsoleServiceParams.ServiceName))
                                //{
                                ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetEntryAssembly().Location }); // original: GetCallingAssembly
                                                                                                                            // questa soluzione sembra non funzionare, forse perchè c'è la classe Installer nei progetti che effettivamente istallano il servizio!
                                                                                                                            // usiamo la ConsoleServiceParams per customizzare quella parte
                                                                                                                            // todo: comunque inutile girarci attorno i self installer non funzionano bene: meglio fare degli script da powershell!
                                                                                                                            //}
                                                                                                                            //else
                                                                                                                            //{
                                                                                                                            //    ManagedInstallerClass.InstallHelper(new string[] {
                                                                                                                            //        "/ServiceName=" + ConsoleServiceParams.ServiceName,
                                                                                                                            //        "/DisplayName=" + ConsoleServiceParams.ServiceName,
                                                                                                                            //        Assembly.GetEntryAssembly().Location }); // original: GetCallingAssembly
                                                                                                                            //}
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine(ex.Message);
                            }
                            break;
#endif
                        }
                    case "-U":
                    case "/U":
                        {
#if NETSTANDARD2_0
                            throw new NotSupportedException("Use 'sc' to stop and uninstall the service.");
#endif
#if NET45
                            try
                            {
                                ManagedInstallerClass.InstallHelper(new string[] { "/U", Assembly.GetEntryAssembly().Location }); // original: GetCallingAssembly
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine(ex.Message);
                            }
                            break;
#endif
                        }
                    default:
                        using (var service = new TService())
                        {
                            service.RunConsole(args);
                        }
                        break;
                }
            }
            else
            {
                using (var service = new TService())
                {
                    ServiceBase.Run(service);
                }
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Trace.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Trace.WriteLine(ex.InnerException.Message);
                }
            }
            // todo: the application is about to terminate anyway, try to stop everything and save the work (if possible) in a clean way
        }

        private bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            bool isclosing = false;
            // Put your own handler here
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_C_EVENT:
                    isclosing = true;
                    Console.WriteLine("CTRL+C received!");
                    break;

                case CtrlTypes.CTRL_BREAK_EVENT:
                    isclosing = true;
                    Console.WriteLine("CTRL+BREAK received!");
                    break;

                case CtrlTypes.CTRL_CLOSE_EVENT:
                    isclosing = true;
                    // cannot write to it. it's already closed
                    //Console.WriteLine("Program being closed!");
                    break;

                case CtrlTypes.CTRL_LOGOFF_EVENT:
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    isclosing = true;
                    Console.WriteLine("User is logging off!");
                    break;
            }

            // close things the right way if we terminate the console
            if (isclosing)
            {
                // cleanup the things
                OnStop();
                // terminate the environment, so no threads are left behind
                Environment.Exit(-1);
            }

            return true;
        }

        #region unmanaged
        // Declare the SetConsoleCtrlHandler function
        // as external and receiving a delegate.

        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        // A delegate type to be used as the handler routine
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        #endregion
    }
}
