using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public interface IDoctor
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor ValidarCorreo(string correo,string contraseña);
        void remove(int id);
        Doctor DoctorById(int id);
        void editDetails(Doctor obj);
        void add(Doctor obj);
        Doctor docByLogin(LoginTemporal obj);
        int idByApe(string apeDoc);
        bool ValidateDoctor(LoginTemporal login);
    }
}

