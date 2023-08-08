using IQSec_PT.Models;
using IQSec_PT.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQSec_PT.Controllers
{
    public class VehiculosController : Controller
    {

        IVehiculosRepository _IVehiculo;
        public VehiculosController(IVehiculosRepository ivehiculo)
        {
            _IVehiculo = ivehiculo;
        }

        // GET: Vehiculos
        public async Task<ActionResult> Index()
        {

            var vehiculos = await _IVehiculo.ObtenerVehiculos();
            return View(vehiculos);
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Vehiculo vehiculo)
        {
            try
            {
                _IVehiculo.AltaVehiculo(vehiculo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehiculos/Edit/5
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

        // GET: Vehiculos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehiculos/Delete/5
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

        public async Task<JsonResult> getVehiculos()
        {

            return Json(await _IVehiculo.ObtenerVehiculos());
        }
    }
}
