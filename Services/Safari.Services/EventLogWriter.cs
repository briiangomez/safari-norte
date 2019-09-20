using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class EventLogWriter : INotificationAction
    {
        private const string LogFileNameOnly = @"LogFile";
        private const string LogFileExtension = ".txt";
        private const string LogFileDirectory = @"~/App_Data";
        private static string _lofFileName;

        public void ActOnNotification(string message)
        {
            string docPath = "";//System.Web.Hosting.HostingEnvironment.MapPath(LogFileDirectory);

            _lofFileName = MakeLogFileName(false);

            using (StreamWriter writer = new StreamWriter(Path.Combine(docPath, _lofFileName), true))
            {
                writer.WriteLine(message);
            }
        }

        private static string MakeLogFileName(bool isArchive)
        {
            return !isArchive ? $"{LogFileNameOnly}{LogFileExtension}"
                : $"{LogFileNameOnly}{DateTime.UtcNow.ToString("ddMMyyyy_hhmmss")}{LogFileExtension}";
        }
    }
}
