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
    public class MedicoController : Controller
    {
        private IApiProcess<Medico> process;

        public MedicoController(IApiProcess<Medico> process)
        {
            this.process = process;
        }


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


            var Medicos = from c in process.ListarTodos() select c;

            if (!string.IsNullOrEmpty(searchString))
                Medicos = Medicos.Where(s => s.Apellido.Contains(searchString) || s.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    Medicos = Medicos.OrderByDescending(s => s.Apellido);
                    break;
                case "Date":
                    Medicos = Medicos.OrderBy(s => s.FechaNacimiento);
                    break;
                default:
                    Medicos = Medicos.OrderBy(s => s.Apellido);
                    break;
            }


            //return View(Medicos.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Medicos.ToPagedList(pageNumber, pageSize));
        }

        // GET: Medico/Details/5
        public ActionResult Details(int id)
        {
            return View(process.Ver(id));
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medico Medico)
        {
            try
            {
                // TODO: Add insert logic here
                var result = process.Agregar(Medico);
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

                return View(Medico);
            }
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Medico/Edit/5
        [HttpPost]
        public ActionResult Edit(Medico Medico)
        {
            try
            {
                // TODO: Add insert logic here
                process.Editar(Medico);
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

                return View(Medico);
            }
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Medico/Delete/5
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
