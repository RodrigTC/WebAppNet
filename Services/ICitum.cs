using TRABAJO_FINAL.Models;
namespace TRABAJO_FINAL.Services
{
    public interface ICitum
    {
        void add(Citum obj);
        IEnumerable<Citum> GetAllReservas();
        void remove(int id);
        IEnumerable<Citum> GetCitaEspecifica(string nomDoc);
        IEnumerable<Citum> GetCitaByDia(int IdDia, string apeDoc);
        IEnumerable<Citum> GetCitaByUser(int idUser);
        void SendEmail(string from, string to, string subject, string body, string smtpServer, int smtpPort);

    }
}