using PagedList;
using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
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
    public class PrecioController : Controller
    {
        private IPrecioService process;
        private IApiProcess<TipoServicio> TipoSerprocess;

        public PrecioController(PrecioService process, IApiProcess<TipoServicio> TipoSerprocess)
        {
            this.process = process;
            this.TipoSerprocess = TipoSerprocess;
        }
        // GET: EspecieAPI
        //public ActionResult Index()
        //{
        //    EspecieAPIProcess ep = new EspecieAPIProcess();
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


            var clientes = from c in process.ListarTodos() select c;

            if (!string.IsNullOrEmpty(searchString))
                clientes = clientes.Where(s => s.TipoServicio.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    clientes = clientes.OrderByDescending(s => s.TipoServicio.Nombre);
                    break;
                //case "Date":
                //    clientes = clientes.OrderBy(s => s.Id);
                //    break;
                default:
                    clientes = clientes.OrderBy(s => s.FechaDesde);
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(clientes.ToPagedList(pageNumber, pageSize));
        }


        // GET: EspecieAPI/Details/5
        //public ActionResult Details(int id)
        //{

        //    return View(process.Ver(id));
        //}

        // GET: EspecieAPI/Create
        public ActionResult Create()
        {
            var tiposServicio = TipoSerprocess.ListarTodos()
                    .Select(x =>
                            new {
                                Id = x.Id,
                                Nombre = x.Nombre
                            });
            ViewBag.TiposServicio = new SelectList(tiposServicio, "Id", "Nombre");
            return View();
        }

        // POST: EspecieAPI/Create
        [HttpPost]
        public ActionResult Create(Precio especie)
        {
            try
            {
                // TODO: Add insert logic here
                var result = process.Agregar(especie);
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

                return View(especie);
            }
        }

        //// GET: EspecieAPI/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View(process.Ver(id));
        //}

        //// POST: EspecieAPI/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Especie especie)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        process.Editar(especie);
        //        TempData["MessageViewBagName"] = new GenericMessageViewModel
        //        {
        //            Message = "Registro actualizado en la base de datos.", // orivle
        //            MessageType = GenericMessages.success
        //        };

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MessageViewBagName"] = new GenericMessageViewModel
        //        {
        //            Message = ex.Message,
        //            MessageType = GenericMessages.danger,
        //            ConstantMessage = true
        //        };

        //        return View(especie);
        //    }
        //}

        //// GET: EspecieAPI/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View(process.Ver(id));
        //}

        //// POST: EspecieAPI/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        var esp = process.Ver(id);
        //        process.Eliminar(esp);
        //        TempData["MessageViewBagName"] = new GenericMessageViewModel
        //        {
        //            Message = "Registro eliminado de la base de datos.", // orivle
        //            MessageType = GenericMessages.success
        //        };

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MessageViewBagName"] = new GenericMessageViewModel
        //        {
        //            Message = ex.Message,
        //            MessageType = GenericMessages.danger,
        //            ConstantMessage = true
        //        };

        //        return View(process.Ver(id));
        //    }
        //}
    }
}
