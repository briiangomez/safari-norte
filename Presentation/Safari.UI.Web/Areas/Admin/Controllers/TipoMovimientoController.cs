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
    public class TipoMovimientoController : Controller
    {
        private IApiProcess<TipoMovimiento> process;

        public TipoMovimientoController(IApiProcess<TipoMovimiento> process)
        {
            this.process = process;
        }
        // GET: TipoMovimiento
        //public ActionResult Index()
        //{
        //    TipoMovimientoProcess ep = new TipoMovimientoProcess();
        //    return View(process.ListarTodos());
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


            var TipoMovimientos = from c in process.ListarTodos() select c;

            if (!string.IsNullOrEmpty(searchString))
                TipoMovimientos = TipoMovimientos.Where(s => s.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    TipoMovimientos = TipoMovimientos.OrderByDescending(s => s.Nombre);
                    break;
                default:
                    TipoMovimientos = TipoMovimientos.OrderBy(s => s.Id);
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(TipoMovimientos.ToPagedList(pageNumber, pageSize));
        }


        // GET: TipoMovimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var result = process.Agregar(TipoMovimiento);
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

                return View(TipoMovimiento);
            }
        }

        // GET: TipoMovimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoMovimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoMovimiento TipoMovimiento)
        {
            try
            {
                // TODO: Add insert logic here
                process.Editar(TipoMovimiento);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro actualizado en la base de datos.", // orivle
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

                return View(TipoMovimiento);
            }
        }

        // GET: TipoMovimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoMovimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add insert logic here
                var esp = process.Ver(id);
                process.Eliminar(esp);
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
