using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TRABAJO_FINAL.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuario;
        
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        public IActionResult LoginUsuario()
        {
            return View();

        }

        public IActionResult LoginAdmin()
        {
            return View();
        }

        public IActionResult ValidarUsuario(LoginTemporal login)
        {

            if (ModelState.IsValid)
            {
                if (_usuario.ValidateUser(login) == false)
                {
                    return View("LoginUsuario");

                }
                else
                {
                    var u = _usuario.userByLogin(login);
                    HttpContext.Session.SetString("sUsuario", JsonConvert.SerializeObject(u));
                    return RedirectToAction("Index", "Inicio");
                }
                
            }
            else
            {
                return View("LoginUsuario");
            }
        }

        public IActionResult ValidarAdmin(LoginTemporal login)
        {
            
            if (ModelState.IsValid)
            {
                if (_usuario.ValidateAdmin(login) == false)
                {
                    return View("LoginAdmin");

                }
                else
                {
                    var u = _usuario.adminByLogin(login);
                    HttpContext.Session.SetString("sAdmin", JsonConvert.SerializeObject(u));
                    return RedirectToAction("Admin", "Usuario");
                }
                
            }
            else
            {
                    return View("LoginAdmin");
            }
        }

        public IActionResult NuevoUsuario()
        {
            return View();
        }
        public IActionResult GrabarUsuario(Usuario obj)
        {
            if (ModelState.IsValid)
            {
                Usuario pipi = new Usuario();

                pipi.Nombreu = obj.Nombreu;
                pipi.Apellidou = obj.Apellidou;
                pipi.Correou = obj.Correou;
                pipi.Contraseñau = _usuario.Char25(obj.Contraseñau);
                pipi.Nacimiento = obj.Nacimiento;
                pipi.Genero = obj.Genero;
                pipi.Telefono = obj.Telefono;


                _usuario.add(pipi);
                return RedirectToAction("LoginUsuario");
            }
            else
            {
                return View("NuevoUsuario");
            }
        }

        [Route("Usuario/ListaUsuarios")]
        public IActionResult ListaUsuarios()
        {

            return View(_usuario.GetAllUsuarios());
        }


        [Route("Usuario/Eliminar/{codigo}")]
        public IActionResult Eliminar(int codigo)
        {
            _usuario.remove(codigo);
            return RedirectToAction("ListaUsuarios");
        }


        [Route("Usuario/Modificar/{codigo}")]
        public IActionResult Modificar(int codigo)
        {
            return View(_usuario.userById(codigo));
        }

        public IActionResult ModificarUsuario(Usuario usuario)
        {
            _usuario.editDetails(usuario);
            return RedirectToAction("ListaUsuarios");
        }

        [Route("Admin")]
        public IActionResult Admin()
        {
            var objsession = JsonConvert.DeserializeObject<Usuario>
                   (HttpContext.Session.GetString("sAdmin"));
            return View();
        }
    }
}
