using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;

namespace TRABAJO_FINAL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctor _doctor;
        public DoctorController(IDoctor doctor)
        {
            _doctor = doctor;
        }
        //Logeo
        [Route("Doctor/Login")]
        public IActionResult LoginDoctor()
        {
            return View();

        }

        
        public IActionResult ValidarDoctor(LoginTemporal login) 
        {
            if (ModelState.IsValid)
            {

                if (_doctor.ValidateDoctor(login) == false) 
                {
                    return View("LoginDoctor");
                    
                }
                else
                {
                    var o = _doctor.docByLogin(login);
                    HttpContext.Session.SetString("sDoctor", JsonConvert.SerializeObject(o));
                    return RedirectToAction("Index", "InicioDoc");
                }
                
            }
            else
            {
                    return View("LoginDoctor");
            }
        }
        public IActionResult NuevoDoctor()
        {
            return View();
        }
        public IActionResult GrabarDoctor(Doctor obj)
        {
            if (ModelState.IsValid)
            {
                _doctor.add(obj);
                return RedirectToAction("LoginUsuario");
            }
            else
            {
                return View("NuevoDoctor");
            }
        }
        //Lista de doctores
        [Route("Doctor/ListaDocs")]
        public IActionResult ListaDoctors()
        {
            return View(_doctor.GetAllDoctors());
        }

        //Eliminar o modificar
        [Route("Doctor/Eliminar/{codigo}")]
        public IActionResult Eliminar(int codigo)
        {
            _doctor.remove(codigo);
            return RedirectToAction("ListaDoctors");
        }

        [Route("Doctor/Modificar/{codigo}")]
        public IActionResult Modificar(int codigo)
        {
            return View(_doctor.DoctorById(codigo));
        }

        public IActionResult ModificarDoctor(Doctor doctor)
        {
            _doctor.editDetails(doctor);
            return RedirectToAction("ListaDoctors");
        }

    }
}
