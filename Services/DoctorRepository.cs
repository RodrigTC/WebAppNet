using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class DoctorRepository : IDoctor
    {
        private ClinicaP conexion = new ClinicaP();

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return conexion.Doctors;
        }
        public void add(Doctor obj)
        {
            conexion.Doctors.Add(obj);
            conexion.SaveChanges();
        }
        public Doctor ValidarCorreo(string correo, string contraseña)
        {
            var obj = (from tdoc in conexion.Doctors
                       where tdoc.CorreoD == correo
                       && tdoc.ContraseñaD == contraseña
                       select tdoc).Single();
            return obj;
        }
        public bool ValidateDoctor(LoginTemporal obj)
        {
            var objuser = (from tdoc in conexion.Doctors
                              where tdoc.CorreoD == obj.Correou
                              && tdoc.ContraseñaD == obj.Contraseñau
                              select tdoc).FirstOrDefault();
            if (objuser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void remove(int id)
        {
            var obj = (from tdoc in conexion.Doctors
                       where tdoc.IdDoctor == id
                       select tdoc).Single();
            conexion.Doctors.Remove(obj);
            conexion.SaveChanges();

        }
        
        public Doctor DoctorById(int id)
        {
            var obj = (from tdoc in conexion.Doctors
                       where tdoc.IdEspecialidad == id
                       select tdoc).Single();

            return obj;

        }

       
        
        public void editDetails(Doctor obj)
        {
            var objAModificar = (from tdoc in conexion.Doctors
                                 where tdoc.IdDoctor == obj.IdDoctor
                                 select tdoc).FirstOrDefault();
            objAModificar.NombreD = obj.NombreD;
            objAModificar.ApellidoD = obj.ApellidoD;
            objAModificar.CorreoD = obj.CorreoD;
            conexion.SaveChanges();
        }
        public Doctor docByLogin(LoginTemporal obj)
        {
            var o = (from tdoc in conexion.Doctors
                     where tdoc.CorreoD == obj.Correou 
                     && tdoc.ContraseñaD == obj.Contraseñau
                     select tdoc).Single();

            return o;
        }

        public int idByApe(string apeDoc)
        {
            var o = (from tdoc in conexion.Doctors
                     where tdoc.ApellidoD == apeDoc
                     select tdoc).Single();
            return o.IdDoctor;
        }
    }
}
