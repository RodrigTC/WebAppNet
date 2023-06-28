using TRABAJO_FINAL.Models;
namespace TRABAJO_FINAL.Services
{
    public interface IUsuario
    {
        void add(Usuario obj);
        Usuario userByLogin(LoginTemporal obj);
        Usuario adminByLogin(LoginTemporal obj);
        bool ValidateUser(LoginTemporal obj);
        bool ValidateAdmin(LoginTemporal obj);
        Usuario userById(int id);
        void editDetails(Usuario obj);
        IEnumerable<Usuario> GetAllUsuarios();
        void remove(int id);
        int idByNom(string nom);
        Usuario userByNom(string Apellidou, string Nombreu);
        IEnumerable<Usuario> GetUsuario(int id);
        string CalculateSHA256(string input);

        string TruncateString(string str, int maxLength);

        string Char25(string input);
        string idByCorreo(string nom);

    }
}
