using PagedList;
using Safari.Entities;
using Safari.UI.Process;
using Safari.UI.Process.APIProcess;
using Safari.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private IApiProcess<Cliente> process;

        public ClienteController(IApiProcess<Cliente> process)
        {
            this.process = process;
        }
        // GET: Cliente
        //[Route("cliente", Name = "ClienteControllerRouteIndex")]
        //public ActionResult Index()
        //{
        //    ClienteProcess ep = new ClienteProcess();
        //    return View(ep.ListarTodos().ToPagedList());
        //}

        //public ActionResult Index(string sortOrder)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        //    ClienteProcess ep = new ClienteProcess();
        //    var clientes = from c in ep.ListarTodos() select c;
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            clientes = clientes.OrderByDescending(s => s.Apellido);
        //            break;
        //        case "Date":
        //            clientes = clientes.OrderBy(s => s.FechaNacimiento);
        //            break;
        //        default:
        //            clientes = clientes.OrderBy(s => s.Apellido);
        //            break;
        //    }
        //    return View(clientes.ToList());
        //}

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;


            ViewBag.CurrentFilter = searchString;


            var clientes = from c in process.ListarTodos() select c;

            if (!string.IsNullOrEmpty(searchString))
                clientes = clientes.Where(s => s.Apellido.Contains(searchString) || s.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    clientes = clientes.OrderByDescending(s => s.Apellido);
                    break;
                case "date_desc":
                    clientes = clientes.OrderBy(s => s.FechaNacimiento);
                    break;
                default:
                    clientes = clientes.OrderBy(s => s.Apellido);
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(clientes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View(process.Ver(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here
                var result = process.Agregar(cliente);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro agregado a la base de datos.", // orivle
                    MessageType = GenericMessages.success
                };

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = ex.Message,
                    MessageType = GenericMessages.danger,
                    ConstantMessage = true
                };

                return View(cliente);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                // TODO: Add insert logic here
                process.Editar(cliente);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro actualizado a la base de datos.", // orivle
                    MessageType = GenericMessages.success
                };

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = ex.Message,
                    MessageType = GenericMessages.danger,
                    ConstantMessage = true
                };

                return View(cliente);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add insert logic here
                var result = process.Ver(id);
                process.Eliminar(result);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro eliminado de la base de datos.", // orivle
                    MessageType = GenericMessages.success
                };

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = ex.Message,
                    MessageType = GenericMessages.danger,
                    ConstantMessage = true
                };

                return View(process.Ver(id));
            }
        }
    }
}
