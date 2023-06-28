using Microsoft.AspNetCore.Mvc;
using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;

namespace TRABAJO_FINAL.Controllers
{
    public class HorarioController : Controller
    {
        private readonly IHorario _horario;
        public HorarioController(IHorario horario)
        {
            _horario = horario;
        }
        [Route("Horario/Index")]
        public IActionResult Index()
        {
            return View(_horario.GetAllHours());
        }

        //Agregar especialidades
        public IActionResult NuevoHorario()
        {
            return View();
        }
        public IActionResult GrabarHorario(Horario obj)
        {
            _horario.add(obj);
            return RedirectToAction("ListaHorarios");
        }

    }
}
