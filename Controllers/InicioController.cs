using TRABAJO_FINAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TRABAJO_FINAL.Services;

namespace TRABAJO_FINAL.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuario _usu;
        private readonly ICitum _cita;
        public InicioController(IUsuario usuario, ICitum cita)
        {
            _usu = usuario;
            _cita = cita;
        }
        public IActionResult Index()
        {
            var objsession = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("sUsuario"));
            //Usuario u = _usu.userByNom(objsession.Nombreu, objsession.Apellidou);
            var nom = objsession.Nombreu;
            var ape = objsession.Apellidou;

            var usu = _usu.userByNom(ape, nom);

            ViewData["ape"] = usu.Apellidou;
            ViewData["nom"] = usu.Nombreu;


            var id = usu.IdUser;

            return View(_usu.GetUsuario(id));

        }

        [Route("Inicio/CitasUser/{idUser}")]
        public IActionResult CitasUser(int idUser)
        {

            return View(_cita.GetCitaByUser(idUser));
        }

        [Route("Inicio/CancelarCita/{codigo}")]
        public IActionResult CancelarCita(int codigo)
        {
            _cita.remove(codigo);
            return RedirectToAction("Index");
        }

    }
}
