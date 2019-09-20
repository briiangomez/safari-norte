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
    public class TipoMovimientoController : Controller
    {
        private TipoMovimientoProcess _TipoMovimientoProcess = new TipoMovimientoProcess();
        // GET: TipoMovimiento
        public ActionResult Index()
        {
            return View(_TipoMovimientoProcess.ListarTodos());
        }

        // GET: TipoMovimiento/Details/5
        public ActionResult Details(int id)
        {
            return View(_TipoMovimientoProcess.Listar(id));
        }

        // GET: TipoMovimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimiento/Create
        [HttpPost]
        public ActionResult Create(TipoMovimiento TipoMovimiento)
        {
            try
            {
                // TODO: Add insert logic here
                _TipoMovimientoProcess.Agregar(TipoMovimiento);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMovimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_TipoMovimientoProcess.Listar(id));
        }

        // POST: TipoMovimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoMovimiento entity)
        {
            try
            {
                // TODO: Add update logic here
                _TipoMovimientoProcess.Actualizar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoMovimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_TipoMovimientoProcess.Listar(id));
        }

        // POST: TipoMovimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _TipoMovimientoProcess.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ExportarTipoMovimientosCSV()
        {
            var biz = new TipoMovimientoProcess();
            var TipoMovimientos = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in TipoMovimientos)
            {
                var properties = typeof(TipoMovimiento).GetProperties();
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

        public void ExportarTipoMovimientosXML()
        {
            var biz = new TipoMovimientoProcess();
            var TipoMovimientos = biz.ListarTodos();

            var serializer = new XmlSerializer(TipoMovimientos.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, TipoMovimientos);
        }
    }
}
