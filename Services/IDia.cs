using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public interface IDia
    {
        int idByDia(string Dia);
        string diaById(int id);
        IEnumerable<Dium> GetAllDias(); 
    }
}
