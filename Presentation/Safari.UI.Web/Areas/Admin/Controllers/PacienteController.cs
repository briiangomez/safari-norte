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
    public class PacienteController : Controller
    {
        private IApiProcess<Paciente> process;

        public PacienteController(IApiProcess<Paciente> process)
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


            var Pacientes = from c in process.ListarTodos() select c;

            if (!string.IsNullOrEmpty(searchString))
                Pacientes = Pacientes.Where(s => s.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    Pacientes = Pacientes.OrderByDescending(s => s.Nombre);
                    break;
                case "Date":
                    Pacientes = Pacientes.OrderBy(s => s.FechaNacimiento);
                    break;
                default:
                    Pacientes = Pacientes.OrderBy(s => s.Id);
                    break;
            }


            //return View(Pacientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Pacientes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            return View(process.Ver(id));
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(Paciente Paciente)
        {
            try
            {
                // TODO: Add insert logic here
                var result = process.Agregar(Paciente);
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

                return View(Paciente);
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(Paciente Paciente)
        {
            try
            {
                // TODO: Add insert logic here
                process.Editar(Paciente);
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

                return View(Paciente);
            }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Paciente/Delete/5
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
