using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;

namespace TRABAJO_FINAL.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitum _cita;
        private readonly IEspecialidad _esp;
        private readonly IDoctor _doc;
        private readonly IHorario _horario;
        private readonly ICTemporal _ctemp;
        private readonly IUsuario _usu;
        private readonly IDia _dia;

        public CitaController(ICitum cita, IEspecialidad esp,
            IDoctor doc, IHorario horario, ICTemporal ctemp, IUsuario usuario, IDia dia)
        {
            _cita = cita;
            _esp = esp;
            _doc = doc;
            _horario = horario;
            _ctemp = ctemp;
            _usu = usuario;
            _dia = dia;
        }



        //1
        public IActionResult ReservaCita()
        {
            var obj = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("sUsuario"));
            ViewData["apel"] = obj.Apellidou;
            ViewData["nomb"] = obj.Nombreu;

            return View(_esp.GetAllEspecs());
        }



        //Encuentra el doctor segun la especialidad elegida
        public IActionResult ReCiDoctor(int id)
        {
            //obtener nombres y apellido
            var obj = JsonConvert.DeserializeObject<Usuario>
                    (HttpContext.Session.GetString("sUsuario"));
            TempData["apel"] = obj.Apellidou;
            TempData["nomb"] = obj.Nombreu;

            //obtener nombre de la especialidad
            var nomesp = _esp.EspById(id);
            TempData["esp"] = nomesp;

            //obtener nombre del doctor
            var nomdoc = _doc.DoctorById(id);
            TempData["nomdoc"] = nomdoc.NombreD;
            TempData["apedoc"] = nomdoc.ApellidoD;

            return RedirectToAction("GuardarCitaTemp");
            
        }

        //3 
        public IActionResult GuardarCitaTemp()
        {
            return View();
        }



        //4 MUESTRA LA CONFIRMACION
        public IActionResult GrabarCita(string nomUsu, 
            string apeDoc,string nomEsp,TimeSpan hora,
            string dia,double costo)
        {
            Citum obj = new Citum();

            var idUsu = _usu.idByNom(nomUsu);
            var idDoc = _doc.idByApe(apeDoc);
            var idEsp = _esp.idByEspe(nomEsp);
            var idHor = _horario.idByHour(hora);
            var idDia = _dia.idByDia(dia);

            obj.IdUser = idUsu;
            obj.NomUser = nomUsu;

            obj.IdDoctor = idDoc;
            obj.NomDoctor = apeDoc;

            obj.IdEspecialidad = idEsp;
            obj.NomEspecialidad = nomEsp;

            obj.IdHorarios = idHor;
            obj.Horario = hora;

            obj.IdDia = idDia;
            obj.Dia = dia;

            obj.Costo = costo;

            _cita.add(obj);
            // Envío de correo electrónico
            string from = "bdpprueba@gmail.com"; // Dirección de correo del remitente
            string to = _usu.idByCorreo(nomUsu); // Dirección de correo del destinatario
            string subject = "Nuevo objeto agregado"; // Asunto del correo electrónico
            string body = $"Se ha agregado un nuevo objeto con el ID: {obj.IdCita}"; // Cuerpo del correo electrónico

            string smtpServer = "bdpprueba@gmail.com"; // Reemplaza con el servidor SMTP adecuado
            int smtpPort = 587; // Reemplaza con el puerto correspondiente

            _cita.SendEmail(from, to, subject, body, smtpServer, smtpPort);


            return View();
        
        }


        [Route("Cita/ListarReservas")]
        public IActionResult ListarReservas()
        {
            return View(_cita.GetAllReservas());
        }



        [Route("Cita/Eliminar/{codigo}")]
        public IActionResult Eliminar(int codigo)
        {
            _cita.remove(codigo);
            return RedirectToAction("ListarReservas");
        }


    }
}
