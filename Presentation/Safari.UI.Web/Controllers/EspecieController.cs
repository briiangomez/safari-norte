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
    public class EspecieController : Controller
    {
        private EspecieProcess _EspecieProcess = new EspecieProcess();
        // GET: Especie
        public ActionResult Index()
        {
            return View(_EspecieProcess.ListarTodos());
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            return View(_EspecieProcess.Listar(id));
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Especie especie)
        {
            try
            {
                // TODO: Add insert logic here
                _EspecieProcess.Agregar(especie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_EspecieProcess.Listar(id));
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(Especie entity)
        {
            try
            {
                // TODO: Add update logic here
                _EspecieProcess.Actualizar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_EspecieProcess.Listar(id));
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _EspecieProcess.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ExportarEspeciesCSV()
        {
            var biz = new EspecieProcess();
            var especies = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in especies)
            {
                var properties = typeof(Especie).GetProperties();
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

        public void ExportarEspeciesXML()
        {
            var biz = new EspecieProcess();
            var especies = biz.ListarTodos();

            var serializer = new XmlSerializer(especies.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, especies);
        }
    }
}
