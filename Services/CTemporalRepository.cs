using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class CTemporalRepository : ICTemporal
    {
        private List<CitaTemporal> lst = new List<CitaTemporal>();
        public void add(CitaTemporal obj)
        {
            lst.Add(obj);

        }
        public IEnumerable<CitaTemporal> GetCitaTemp()
        {
            return lst;
        }
    }
}
