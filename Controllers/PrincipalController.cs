using Microsoft.AspNetCore.Mvc;

namespace TRABAJO_FINAL.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RedirectToCita()
        {
            return RedirectToAction("ReservaCita","Cita");
        }
        public IActionResult RedirectToCredi()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RedirectToContac()
        {
            return RedirectToAction("Contactos", "Home");
        }
        public IActionResult RedirectToAdmin()
        {
            return RedirectToAction("LoginAdmin", "Usuario");
        }

        public IActionResult RedirectToLogin()
        {
            return RedirectToAction("LoginUsuario", "Usuario");
        }
        public IActionResult RedirectToDoctor()
        {
            return RedirectToAction("LoginDoctor", "Doctor");
        }


        [Route("Prueba")]
        public IActionResult Prueba()
        {
            return View();
        }

    }
}
