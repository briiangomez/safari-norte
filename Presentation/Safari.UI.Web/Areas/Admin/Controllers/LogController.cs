using Safari.Framework.Logging;
using Safari.UI.Web.Areas.Admin.Models;
using Safari.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class LogController : Controller
    {
        private ILoggingService _loggingService;

        public LogController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        public ActionResult Index()
        {
            IList<LogEntry> logs = new List<LogEntry>();

            try
            {
                logs = _loggingService.ListLogFile();
            }
            catch (Exception ex)
            {
                var err = $"No se puede acceder a los registros: {ex.Message}";
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = err,
                    MessageType = GenericMessages.danger
                };

                _loggingService.Error(err);
            }

            return View(new ListLogViewModel { LogFiles = logs });
        }

        public ActionResult ClearLog()
        {
            _loggingService.ClearLogFiles();

            TempData["MessageViewBagName"] = new GenericMessageViewModel
            {
                Message = "Archivo de registro borrado",
                MessageType = GenericMessages.success
            };
            return RedirectToAction("Index");
        }
    }
}