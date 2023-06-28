using Microsoft.AspNetCore.Mvc;
using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;

namespace TRABAJO_FINAL.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IEspecialidad _especialidad;
        public EspecialidadController(IEspecialidad especialidad)
        {
            _especialidad = especialidad;
        }
        [Route("Especialidad/Index")]
        public IActionResult Index()
        {
            return View(_especialidad.GetAllEspecs());
        }

        //Agregar especialidades
        public IActionResult NuevaEspecialidad()
        {
            return View();
        }
        public IActionResult GrabarEspecialidad(Especialidad obj)
        {
            _especialidad.add(obj);
            return RedirectToAction("ListaEspecialidades");
        }
    }
}
