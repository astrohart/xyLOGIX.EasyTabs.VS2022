using PostSharp.Patterns.Diagnostics;
using Alphaleonis.Win32.Filesystem;
using Core.Assemblies.Info;
using Core.Logging;
using Core.Logging.Constants;
using Core.Win32.Interact;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DemoApp
{
    /// <summary>
    /// Defines the behavior of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            LoggingSubsystemManager.InitializeLogging(
                muteConsole: false,
                infrastructureType: LoggingInfrastructureType.PostSharp,
                logFileName: Get.LogFilePath(),
                applicationName: Get.ApplicationProductName()
            );

            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException
            );
            Application.ThreadException += OnApplicationThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainWindow());
        }

        /// <summary>
        /// Handles the <see cref="E:System.Windows.Forms.Application.ThreadException" />
        /// event raised by the <c>Application</c> object when an unhandled exception is
        /// thrown.
        /// </summary>
        /// <param name="sender">
        /// Reference to an instance of the object that raised the
        /// event.
        /// </param>
        /// <param name="e">
        /// A <see cref="T:System.Threading.ThreadExceptionEventArgs" />
        /// that contains the event data.
        /// </param>
        /// <remarks>
        /// This method responds by displaying an error message box with the
        /// exception message's text.
        /// </remarks>
        private static void OnApplicationThreadException(
            [NotLogged] object sender,
            [NotLogged] ThreadExceptionEventArgs e
        )
        {
            // dump all the exception info to the log
            DebugUtils.LogException(e.Exception);

            Messages.ShowStopError(e.Exception.Message);
        }

        /// <summary>
        /// Exposes static methods to obtain data from various data sources.
        /// </summary>
        private static class Get
        {
            /// <summary>
            /// A <see cref="T:System.String" /> containing the final piece of the path of the
            /// log file.
            /// </summary>
            private static readonly string LOG_FILE_PATH_TERMINATOR =
                $@"{AssemblyCompany}\{AssemblyProduct}\Logs\{AssemblyTitle}_log.txt";

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains the product name defined
            /// for this application.
            /// </summary>
            /// <remarks>
            /// This property is really an alias for the
            /// <see cref="P:AssemblyMetadata.AssemblyCompany" /> property.
            /// </remarks>
            private static string AssemblyCompany
                => AssemblyMetadata.AssemblyCompany;

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains the product name defined
            /// for this application.
            /// </summary>
            /// <remarks>
            /// This property is really an alias for the
            /// <see cref="P:AssemblyMetadata.AssemblyProduct" /> property.
            /// </remarks>
            private static string AssemblyProduct
                => AssemblyMetadata.AssemblyProduct.Replace(
                    "xyLOGIX ", string.Empty
                );

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains the assembly title defined
            /// for this application.
            /// </summary>
            /// <remarks>
            /// This property is really an alias for the
            /// <see cref="P:AssemblyMetadata.AssemblyTitle" /> property.
            /// </remarks>
            private static string AssemblyTitle
                => AssemblyMetadata.AssemblyTitle.Replace(" ", "_");

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains a user-friendly name for
            /// the software product of which this application or class library is a part.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String" /> that contains a user-friendly name
            /// for the software product of which this application or class library is a part.
            /// </returns>
            public static string ApplicationProductName()
            {
                string result;

                try
                {
                    result = AssemblyProduct;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = string.Empty;
                }

                return result;
            }

            /// <summary>
            /// Obtains a <see cref="T:System.String" /> that contains the fully-qualified
            /// pathname of the file that should be used for logging messages.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String" /> that contains the fully-qualified
            /// pathname of the file that should be used for logging messages.
            /// </returns>
            public static string LogFilePath()
                => Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.CommonApplicationData
                    ), LOG_FILE_PATH_TERMINATOR
                );
        }
    }
}