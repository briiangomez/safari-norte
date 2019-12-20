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
    public class MovimientoController : Controller
    {
        private IApiProcess<Movimiento> process;
        private IApiProcess<TipoMovimiento> Tipoprocess;
        private IApiProcess<Cliente> Cliprocess;

        public MovimientoController(IApiProcess<Movimiento> process, IApiProcess<TipoMovimiento> Tipoprocess, IApiProcess<Cliente> Cliprocess)
        {
            this.process = process;
            this.Tipoprocess = Tipoprocess;
            this.Cliprocess = Cliprocess;
        }
        // GET: Movimiento
        //public ActionResult Index()
        //{
        //    MovimientoProcess ep = new MovimientoProcess();
        //    return View(process.ListarTodos());
        //}
        [Route("movimiento", Name = "MovimientoControllerRouteIndex")]
        [Authorize]
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


            var Movimientos = from c in process.ListarTodos() select c;

            var Movimientoss = new List<MovimientoVM>();
            var clientes = Cliprocess.ListarTodos();
            foreach (var item in clientes)
            {
                var movs = Movimientos.Where(o => o.ClienteId == item.Id).OrderByDescending(o => o.Fecha);
                if(movs.Count() > 0)
                {
                    MovimientoVM mov = new MovimientoVM();
                    mov.Cliente = item;
                    mov.idCliente = item.Id;
                    mov.FechaUltimoMov = movs.FirstOrDefault().Fecha;
                    mov.saldo = movs.Sum(o => o.Valor);
                    Movimientoss.Add(mov);
                }
            }

            if (!string.IsNullOrEmpty(searchString))
                Movimientoss = Movimientoss.Where(s => s.Cliente.Nombre.Contains(searchString)).ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    Movimientoss = Movimientoss.OrderByDescending(s => s.Cliente.Nombre).ToList();
                    break;
                case "date_desc":
                    Movimientoss = Movimientoss.OrderByDescending(s => s.FechaUltimoMov).ToList();
                    break;
                default:
                    Movimientoss = Movimientoss.OrderBy(s => s.idCliente).ToList();
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Movimientoss.ToPagedList(pageNumber, pageSize));
        }

        [Route("movimiento-por-cliente", Name = "MovimientoClienteControllerRouteIndex")]
        [Authorize]
        public ViewResult IndexByCliente(int idCliente, string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;


            ViewBag.CurrentFilter = searchString;


            var Movimientos = from c in process.ListarTodos().Where(o => o.ClienteId == idCliente) select c;

            if (!string.IsNullOrEmpty(searchString))
                Movimientos = Movimientos.Where(s => s.Cliente.Nombre.Contains(searchString)).ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    Movimientos = Movimientos.OrderByDescending(s => s.Cliente.Nombre).ToList();
                    break;
                case "date_desc":
                    Movimientos = Movimientos.OrderByDescending(s => s.Fecha ).ToList();
                    break;
                default:
                    Movimientos = Movimientos.OrderBy(s => s.Id).ToList();
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            Cliente cli = Cliprocess.Ver(idCliente);
            ViewBag.NombreCliente = cli.Nombre;
            ViewBag.idCliente = idCliente;
            return View(Movimientos.ToPagedList(pageNumber, pageSize));
        }



        // GET: Movimiento/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(process.Ver(id));
        }

        // GET: Movimiento/Create
        [Authorize]
        public ActionResult Create()
        {
            var medicos = Cliprocess.ListarTodos().Select(x =>
                            new {
                                Id = x.Id,
                                Nombre = x.Apellido + " " + x.Nombre
                            });
            ViewBag.Clientes = new SelectList(medicos, "Id", "Nombre");

            var pacientes = Tipoprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.TiposMovimiento = new SelectList(pacientes, "Id", "Nombre");
            return View();
        }

        // POST: Movimiento/Create
        [HttpPost]
        public ActionResult Create(Movimiento Movimiento)
        {
            try
            {
                // TODO: Add insert logic here
                var tip = Tipoprocess.Ver(Movimiento.TipoMovimientoId);
                Movimiento.Valor = Movimiento.Valor * tip.Multiplicador;
                var result = process.Agregar(Movimiento);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro agregado a la base de datos.", // orivle
                    MessageType = GenericMessages.success
                };

                return RedirectToAction("IndexByCliente", new { id = Movimiento.ClienteId });

            }
            catch (Exception ex)
            {
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = ex.Message,
                    MessageType = GenericMessages.danger,
                    ConstantMessage = true
                };
                var medicos = Cliprocess.ListarTodos().Select(x =>
                new {
                    Id = x.Id,
                    Nombre = x.Apellido + " " + x.Nombre
                });
                ViewBag.Clientes = new SelectList(medicos, "Id", "Nombre");

                var pacientes = Tipoprocess.ListarTodos()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Nombre
                                 });
                ViewBag.TiposMovimiento = new SelectList(pacientes, "Id", "Nombre");
                return View(Movimiento);
            }
        }

        // GET: Movimiento/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var medicos = Cliprocess.ListarTodos().Select(x =>
                   new {
                       Id = x.Id,
                       Nombre = x.Apellido + " " + x.Nombre
                   });
            ViewBag.Clientes = new SelectList(medicos, "Id", "Nombre");

            var pacientes = Tipoprocess.ListarTodos()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.TiposMovimiento = new SelectList(pacientes, "Id", "Nombre");
            return View(process.Ver(id));
        }

        // POST: Movimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(Movimiento Movimiento)
        {
            try
            {
                // TODO: Add insert logic here
                var tip = Tipoprocess.Ver(Movimiento.TipoMovimientoId);
                Movimiento.Valor = Movimiento.Valor * tip.Multiplicador;
                process.Editar(Movimiento);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro actualizado en la base de datos.", // orivle
                    MessageType = GenericMessages.success
                };

                return RedirectToAction("IndexByCliente", new { id = Movimiento.ClienteId });

            }
            catch (Exception ex)
            {
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = ex.Message,
                    MessageType = GenericMessages.danger,
                    ConstantMessage = true
                };

                return View(Movimiento);
            }
        }

        // GET: Movimiento/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(process.Ver(id));
        }

        // POST: Movimiento/Delete/5
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

                return RedirectToAction("IndexByCliente", new { id = esp.ClienteId });
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
