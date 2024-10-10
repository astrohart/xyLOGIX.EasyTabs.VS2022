using Microsoft.Win32;
using System;

namespace xyLOGIX.EasyTabs
{
    /// <summary>
    /// Exposes static methods to interrogate the operating system.
    /// </summary>
    internal static class OperatingSystem
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the subkey path of the
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion</c> subkey.
        /// </summary>
        internal const string OperatingSystemVersionKeyPath =
            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

        /// <summary>
        /// A <see cref="T:System.String" /> that contains the name of the
        /// <c>ProductName</c> registry value.
        /// </summary>
        internal const string ProductNameValue = "ProductName";

        /// <summary>
        /// Gets a value indicating whether the user is running the client application on
        /// the Windows 10 operating system.
        /// </summary>
        internal static bool IsWindows10
        {
            get
            {
                var result = false;

                try
                {
                    using (var key =
                           Registry.LocalMachine.OpenSubKey(
                               OperatingSystemVersionKeyPath
                           ))
                    {
                        if (key == null) return result;

                        try
                        {
                            var productNameValue =
                                key.GetValue(ProductNameValue);
                            if (productNameValue == null) return result;

                            result = productNameValue.ToString()
                                .StartsWith("Windows 10");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"ERROR: {ex.Message}");

                            result = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");

                    result = false;
                }

                return result;
            }
        }
    }
}