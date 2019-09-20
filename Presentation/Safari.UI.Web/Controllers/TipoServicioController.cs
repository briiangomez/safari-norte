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
    public class TipoServicioController : Controller
    {
        private TipoServicioProcess _TipoServicioProcess = new TipoServicioProcess();
        // GET: TipoServicio
        public ActionResult Index()
        {
            return View(_TipoServicioProcess.ListarTodos());
        }

        // GET: TipoServicio/Details/5
        public ActionResult Details(int id)
        {
            return View(_TipoServicioProcess.Listar(id));
        }

        // GET: TipoServicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicio/Create
        [HttpPost]
        public ActionResult Create(TipoServicio TipoServicio)
        {
            try
            {
                // TODO: Add insert logic here
                _TipoServicioProcess.Agregar(TipoServicio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_TipoServicioProcess.Listar(id));
        }

        // POST: TipoServicio/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoServicio entity)
        {
            try
            {
                // TODO: Add update logic here
                _TipoServicioProcess.Actualizar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_TipoServicioProcess.Listar(id));
        }

        // POST: TipoServicio/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _TipoServicioProcess.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ExportarTipoServiciosCSV()
        {
            var biz = new TipoServicioProcess();
            var TipoServicios = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in TipoServicios)
            {
                var properties = typeof(TipoServicio).GetProperties();
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

        public void ExportarTipoServiciosXML()
        {
            var biz = new TipoServicioProcess();
            var TipoServicios = biz.ListarTodos();

            var serializer = new XmlSerializer(TipoServicios.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, TipoServicios);
        }
    }
}
