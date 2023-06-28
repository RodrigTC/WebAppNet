using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class EspecialidadRepository : IEspecialidad
    {
        private ClinicaP conexion = new ClinicaP();

        public void add(Especialidad obj)
        {
            conexion.Especialidads.Add(obj);
            conexion.SaveChanges();
        }
        public IEnumerable<Especialidad> GetAllEspecs()
        {
            return conexion.Especialidads;
        }

        public string EspById(int id)
        {

            var o = (from tesp in conexion.Especialidads
                     where tesp.IdEspecialidad == id
                     select tesp).Single();
            return o.Descripcion;

        }
        public int idByEspe(string nomEsp)
        {
            var o = (from tesp in conexion.Especialidads
                     where tesp.Descripcion == nomEsp
                     select tesp).Single();
            return o.IdEspecialidad;
        }
    }
}
