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
    public class MascotaController : Controller
    {
        private MascotaProcess _MascotaProcess = new MascotaProcess();
        // GET: Mascota
        public ActionResult Index()
        {
            return View(_MascotaProcess.ListarTodos());
        }

        // GET: Mascota/Details/5
        public ActionResult Details(int id)
        {
            return View(_MascotaProcess.Listar(id));
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascota/Create
        [HttpPost]
        public ActionResult Create(Mascota Mascota)
        {
            try
            {
                // TODO: Add insert logic here
                _MascotaProcess.Agregar(Mascota);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_MascotaProcess.Listar(id));
        }

        // POST: Mascota/Edit/5
        [HttpPost]
        public ActionResult Edit(Mascota entity)
        {
            try
            {
                // TODO: Add update logic here
                _MascotaProcess.Actualizar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_MascotaProcess.Listar(id));
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _MascotaProcess.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ExportarMascotasCSV()
        {
            var biz = new MascotaProcess();
            var Mascotas = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in Mascotas)
            {
                var properties = typeof(Mascota).GetProperties();
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

        public void ExportarMascotasXML()
        {
            var biz = new MascotaProcess();
            var Mascotas = biz.ListarTodos();

            var serializer = new XmlSerializer(Mascotas.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, Mascotas);
        }
    }
}
