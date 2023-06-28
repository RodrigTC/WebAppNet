using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public interface ICTemporal
    {
        void add(CitaTemporal obj);
         IEnumerable<CitaTemporal> GetCitaTemp();
    }
}
