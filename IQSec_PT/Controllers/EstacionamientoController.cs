using IQSec_PT.Models;
using IQSec_PT.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IQSec_PT.Controllers
{
    public class EstacionamientoController : Controller


    {

        IEstacionamientoRepository _IEstacionamiento;
        public EstacionamientoController(IEstacionamientoRepository iestacionamiento)
        {
            _IEstacionamiento = iestacionamiento;
        }

        // GET: EstacionamientoController
        public async Task<ActionResult> Index()
        {
            var registros = await _IEstacionamiento.Registros();
            return View(registros);
        }

        [HttpPost]
        public FileResult ExporttoExcel(string HtmlTable)
        {
            return File(Encoding.ASCII.GetBytes(HtmlTable), "application/vnd.ms-excel", "htmltable.xls");
        }

        // GET: EstacionamientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstacionamientoController/Create
        public ActionResult Create()
        {
            return View();
        }     
        
        public async Task<ActionResult> Salida(int id)
        {

            var r = await _IEstacionamiento.Registro(id);
            return View(r);
        }

        // POST: EstacionamientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create([FromForm] Estacionamiento estacionamiento)
        {
            try
            {
               await _IEstacionamiento.Entrada(estacionamiento.placas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Salida([FromForm] Estacionamiento estacionamiento)
        {
            try
            {
                await _IEstacionamiento.Salida(estacionamiento.estacionamientoID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: EstacionamientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstacionamientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstacionamientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstacionamientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
