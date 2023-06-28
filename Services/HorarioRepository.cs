using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class HorarioRepository : IHorario
    {
        private ClinicaP conexion = new ClinicaP();

        public void add(Horario obj)
        {
            conexion.Horarios.Add(obj);
            conexion.SaveChanges();
        }
        public IEnumerable<Horario> GetAllHours()
        {
            return conexion.Horarios;
        }
        public Horario GetHour(int id)
        {
            var o = (from thor in conexion.Horarios
                     where thor.IdHorarios == id
                     select thor).Single();
            return o;
        }
        public int idByHour(TimeSpan hora)
        {
            var o = (from thor in conexion.Horarios
                     where thor.FechaI == hora
                     select thor).Single();
            return o.IdHorarios;
        }
    }
}
