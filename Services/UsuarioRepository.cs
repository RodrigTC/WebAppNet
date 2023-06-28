using System.Security.Cryptography;
using System.Text;
using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class UsuarioRepository : IUsuario
    {
        private ClinicaP conexion = new ClinicaP();
        private LoginTemporal c = new LoginTemporal();

        public void add(Usuario obj)
        {
            conexion.Usuarios.Add(obj);
            conexion.SaveChanges();
        }
        public Usuario userByLogin(LoginTemporal obj)
        {
            string contraa = Char25(obj.Contraseñau);
            var o = (from tusu in conexion.Usuarios
                     where tusu.Correou == obj.Correou
                     && tusu.Contraseñau == contraa
                     select tusu).Single();

            return o;
        }
        public Usuario adminByLogin(LoginTemporal obj)
        {
            string contraa = Char25(obj.Contraseñau);
            var o = (from tusu in conexion.Usuarios
                     where tusu.Correou == obj.Correou
                     && tusu.Contraseñau == contraa
                     select tusu).Single();

            return o;
        }

        public bool ValidateUser(LoginTemporal obj)
        {
            string contraa = Char25(obj.Contraseñau);
            var objUsuario = (from tusu in conexion.Usuarios
                              where tusu.Correou == obj.Correou
                              && tusu.Contraseñau == contraa
                              select tusu).FirstOrDefault();
            if (objUsuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateAdmin(LoginTemporal obj)
        {

            string contraa = Char25(obj.Contraseñau);
            var objUsuario = (from tusu in conexion.Usuarios
                              where tusu.Contraseñau == contraa
                              && tusu.Correou == "admin@gmail.com"
                              select tusu).FirstOrDefault();
            if (objUsuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Usuario userById(int id)
        {

            var obj = (from tusu in conexion.Usuarios
                       where tusu.IdUser == id
                       select tusu).Single();
            return obj;

        }
        public string idByCorreo(string nom)
        {
            var obj = (from tusu in conexion.Usuarios
                       where tusu.Nombreu == nom
                       select tusu).Single();
            return obj.Correou;
        }

        public void editDetails(Usuario obj)
        {
            var objAModificar = (from tusu in conexion.Usuarios
                                 where tusu.IdUser == obj.IdUser
                                 select tusu).FirstOrDefault();
            objAModificar.Nombreu = obj.Nombreu;
            objAModificar.Apellidou = obj.Apellidou;
            objAModificar.Correou = obj.Correou;
            objAModificar.Telefono = obj.Telefono;
            conexion.SaveChanges();
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return conexion.Usuarios;
        }

        public void remove(int id)
        {
            var obj = (from tusu in conexion.Usuarios
                       where tusu.IdUser == id
                       select tusu).Single();
            conexion.Usuarios.Remove(obj);
            conexion.SaveChanges();
        }
        public int idByNom(string nom)
        {
            var obj = (from tusu in conexion.Usuarios
                       where tusu.Nombreu == nom
                       select tusu).Single();
            return obj.IdUser;
        }
        public Usuario userByNom(string Apellidou, string Nombreu)
        {
            var obj = (from tusu in conexion.Usuarios
                       where tusu.Nombreu == Nombreu
                       && tusu.Apellidou == Apellidou
                       select tusu).Single();
            return obj;

        }
        public IEnumerable<Usuario> GetUsuario(int id)
        {
            return (from tusu in conexion.Usuarios
                    where tusu.IdUser == id 
                    select tusu);
        }
        public string CalculateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string TruncateString(string str, int maxLength)
        {
            if (str.Length > maxLength)
            {
                return str.Substring(0, maxLength);
            }
            return str;
        }

        public string Char25(string input)
        {
            string sha256Hash = CalculateSHA256(input);
            string truncatedHash = TruncateString(sha256Hash, 25);
            // Console.WriteLine("Truncated SHA-256 hash: " + truncatedHash);
            return truncatedHash;
        }

    }
}
