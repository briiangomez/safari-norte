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

namespace Safari.UI.Web.Controllers
{
    public class CitaController : Controller
    {
        private IApiProcess<Cita> process;
        private IApiProcess<Sala> Salaprocess;
        private IApiProcess<Medico> Medicoprocess;
        private IApiProcess<Paciente> Pacienteprocess;
        private IApiProcess<TipoServicio> TipoSerprocess;

        public CitaController(IApiProcess<Cita> process, IApiProcess<Sala> Salaprocess, IApiProcess<Medico> Medicoprocess,
            IApiProcess<Paciente> Pacienteprocess, IApiProcess<TipoServicio> TipoSerprocess)
        {
            this.process = process;
            this.Salaprocess = Salaprocess;
            this.Medicoprocess = Medicoprocess;
            this.Pacienteprocess = Pacienteprocess;
            this.TipoSerprocess = TipoSerprocess;
        }
        // GET: Cita
        //public ActionResult Index()
        //{
        //    CitaProcess ep = new CitaProcess();
        //    return View(process.ListarTodos());
        //}
        [Route("cita", Name = "CitaControllerRouteIndex")]
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


            var citas = from c in process.ListarTodos() select c;

            if (!string.IsNullOrEmpty(searchString))
                citas = citas.Where(s => s.Paciente.Nombre.Contains(searchString) ||
                s.Medico.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    citas = citas.OrderByDescending(s => s.Paciente.Nombre);
                    break;
                default:
                    citas = citas.OrderBy(s => s.Paciente.Nombre);
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(citas.ToPagedList(pageNumber, pageSize));
        }


        // GET: Cita/Details/5
        public ActionResult Details(int id)
        {
            return View(process.Ver(id));
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            var medicos = Medicoprocess.ListarTodos().Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Apellido + " " + x.Nombre
                             });
            ViewBag.Medicos = new SelectList(medicos, "Id", "Nombre");

            var pacientes = Pacienteprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nombre");

            var salas = Salaprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.Salas = new SelectList(salas, "Id", "Nombre");

            var tiposServicio = TipoSerprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.TiposServicio = new SelectList(tiposServicio, "Id", "Nombre");
            return View();
        }

        public ActionResult ObtenerCitas()
        {
            return Json(process.ListarTodos().Select(x => new {
                Desc = x.Medico.Nombre + " " + x.Medico.Apellido + "- " + x.Medico.Especialidad,
                Start_Date = x.Fecha,
                End_Date = x.Fecha.AddHours(1),
                Title = x.TipoServicio.Nombre + " - " + x.Paciente.Nombre,
                url = "/Cita/Details/" + x.Id
            }), JsonRequestBehavior.AllowGet);
        }

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita Cita)
        {
            try
            {
                // TODO: Add insert logic here
                Cita.Fecha = this.GetCitas(Cita.Fecha);
                if (Cita.Fecha.Hour == 0)
                    throw new Exception("No se puede cargar mas citas durante el dia de hoy!");
                var result = process.Agregar(Cita);
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

                return View(Cita);
            }
        }

        public DateTime GetCitas(DateTime hora)
        {
            try
            {
                var man = hora.AddDays(1);
                var citas = process.ListarTodos().Where(o => o.Fecha > hora && o.Fecha < man).OrderByDescending(o => o.Fecha).ToList();
                if(citas.Count == 10)
                {
                    return hora;
                }
                if(citas.Count() > 0)
                {
                    return hora.AddHours(citas.FirstOrDefault().Fecha.Hour + 1);
                }
                else
                {
                    return hora.AddHours(8);
                }

            }
            catch(Exception ex)
            {
                return hora;
            }
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            var medicos = Medicoprocess.ListarTodos().Select(x =>
                   new {
                       Id = x.Id,
                       Nombre = x.Apellido + " " + x.Nombre
                   });
            ViewBag.Medicos = new SelectList(medicos, "Id", "Nombre");

            var pacientes = Pacienteprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nombre");

            var salas = Salaprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.Salas = new SelectList(salas, "Id", "Nombre");

            var tiposServicio = TipoSerprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.TiposServicio = new SelectList(tiposServicio, "Id", "Nombre");
            return View(process.Ver(id));
        }

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(Cita Cita)
        {
            try
            {
                // TODO: Add insert logic here
                process.Editar(Cita);
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

                return View(Cita);
            }
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Cita/Delete/5
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
