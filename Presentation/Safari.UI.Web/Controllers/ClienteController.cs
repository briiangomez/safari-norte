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
    public class ClienteController : Controller
    {
        private ClienteProcess _ClienteProcess = new ClienteProcess();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(_ClienteProcess.ListarTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View(_ClienteProcess.Listar(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente Cliente)
        {
            try
            {
                // TODO: Add insert logic here
                _ClienteProcess.Agregar(Cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ClienteProcess.Listar(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente entity)
        {
            try
            {
                // TODO: Add update logic here
                _ClienteProcess.Actualizar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ClienteProcess.Listar(id));
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _ClienteProcess.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ExportarClientesCSV()
        {
            var biz = new ClienteProcess();
            var Clientes = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in Clientes)
            {
                var properties = typeof(Cliente).GetProperties();
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

        public void ExportarClientesXML()
        {
            var biz = new ClienteProcess();
            var Clientes = biz.ListarTodos();

            var serializer = new XmlSerializer(Clientes.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, Clientes);
        }
    }
}
