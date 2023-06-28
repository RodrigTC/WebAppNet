using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;

namespace TRABAJO_FINAL.Controllers
{
    public class InicioDocController : Controller
    {
        private readonly ICitum _cita;
        private readonly IDia _dia;

        public InicioDocController(ICitum cita, IDia dia)
        {
            _cita = cita;
            _dia = dia;
        }

        public IActionResult Index()
        {
            var obj = JsonConvert.DeserializeObject<Doctor>
                    (HttpContext.Session.GetString("sDoctor"));
            ViewData["ape"] = obj.ApellidoD;
            
            var ape = obj.ApellidoD;
            return View(_cita.GetCitaEspecifica(ape));
            
        }
        public IActionResult SelectDia() 
        {
            return View(_dia.GetAllDias());
        }
        [Route("InicioDoc/CitasPorDia/{idDia}")]

        public IActionResult CitasPorDia(int idDia)
        {
            var obj = JsonConvert.DeserializeObject<Doctor>
                    (HttpContext.Session.GetString("sDoctor")); 
            var ape = obj.ApellidoD;

            @ViewData["dia"] = _dia.diaById(idDia);
            return View(_cita.GetCitaByDia(idDia,ape));
        }
    }
}
