using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void WriteValueToAppSettings(string key, string value)
        {
            if (ConfigurationManager.AppSettings.Keys.Cast<string>().Contains(key))
                ConfigurationManager.AppSettings.Remove(key);
            ConfigurationManager.AppSettings.Add(key, value);
        }
        static void ReadConfigDynamically()
        {
            Console.WriteLine("-AppSettings-");
            foreach (var varName in ConfigurationManager.AppSettings.AllKeys)
                Console.WriteLine($"{varName}: {ConfigurationManager.AppSettings[varName]}");

            Console.WriteLine("\n-Connection Strings-");
            foreach (var varName in ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>())
                Console.WriteLine($"{varName.Name}: {varName.ConnectionString}");
        }
        static void ReadConfigInvidually()
        {
            string[] appSettingVarKeys = new string[]
            {
                "TempFilePath",
                "UserName",
                "SystemEmailAddress",
                "ServerIPAddress"
            };

            Console.WriteLine("-AppSettings-");
            foreach(var varName in appSettingVarKeys)
                Console.WriteLine($"{varName}: {ConfigurationManager.AppSettings[varName]}");

            string[] connectionStringKeys = new string[]
            {
                "Default",
                "CustomerDB",
                "AuthDB"
            };

            Console.WriteLine("\n-Connection Strings-");
            foreach(var varName in connectionStringKeys)
                Console.WriteLine($"{varName}: {ConfigurationManager.ConnectionStrings[varName]}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***Individual Config Reads***");
            ReadConfigInvidually();

            Console.WriteLine("\n\n***Dynamic Config Reads***");
            ReadConfigDynamically();

            Console.WriteLine("\n\n***Writing New Value to AppSettings***");
            Console.WriteLine("Unimplemented");
            //WriteValueToAppSettings("test", "test");
            Console.ReadLine();
        }
    }
}
