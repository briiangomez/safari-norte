using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class SalaController : Controller
    {
        private SalaProcess _SalaProcess = new SalaProcess();
        // GET: Sala
        public ActionResult Index()
        {
            return View(_SalaProcess.ListarTodos());
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View(_SalaProcess.Listar(id));
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        public ActionResult Create(Sala Sala)
        {
            try
            {
                // TODO: Add insert logic here
                _SalaProcess.Agregar(Sala);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_SalaProcess.Listar(id));
        }

        // POST: Sala/Edit/5
        [HttpPost]
        public ActionResult Edit(Sala entity)
        {
            try
            {
                // TODO: Add update logic here
                _SalaProcess.Actualizar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_SalaProcess.Listar(id));
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _SalaProcess.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ExportarSalasCSV()
        {
            var biz = new SalaProcess();
            var Salas = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in Salas)
            {
                var properties = typeof(Sala).GetProperties();
                foreach (var prop in properties)
                {
                    streamWriter.Write(GetValue(item, prop.Name));
                    streamWriter.Write(", ");
                }
                streamWriter.WriteLine();
            }

            streamWriter.Flush();
            stream.Position = 0;

            return File(stream, "text/csv");
        }

        private static string GetValue(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null).ToString() ?? "";
        }

        public void ExportarSalasXML()
        {
            var biz = new SalaProcess();
            var Salas = biz.ListarTodos();

            var serializer = new XmlSerializer(Salas.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, Salas);
        }
    }
}
