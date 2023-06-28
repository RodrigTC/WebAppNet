using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public interface IHorario
    {
        void add(Horario obj);
        IEnumerable<Horario> GetAllHours();
        Horario GetHour(int id);
        int idByHour(TimeSpan hora);
    }
}
