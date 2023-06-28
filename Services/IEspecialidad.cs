using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public interface IEspecialidad
    {
        void add(Especialidad obj);
        IEnumerable<Especialidad> GetAllEspecs();
        string EspById(int id);
        int idByEspe(string nomEsp);
    }
}
