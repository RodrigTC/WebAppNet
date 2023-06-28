using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class DiaRepository : IDia
    {
        private ClinicaP conexion = new ClinicaP();
        public int idByDia(string Dia)
        {
            var o = (from tdia in conexion.Dia
                     where tdia.Dia == Dia
                     select tdia).Single();
            return o.IdDia;
        }
        public IEnumerable<Dium> GetAllDias()
        {
            return conexion.Dia;
        }
        public string diaById(int id)
        {
            var dia = (from tdia in conexion.Dia
                       where tdia.IdDia== id
                       select tdia).Single();
            return dia.Dia;
        }
    }
}
