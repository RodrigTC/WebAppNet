using System.Net.Mail;
using System.Net;
using TRABAJO_FINAL.Models;

namespace TRABAJO_FINAL.Services
{
    public class CitumRepository : ICitum
    {
        private ClinicaP conexion = new ClinicaP();
        public void add(Citum obj)
        {
            conexion.Cita.Add(obj);
            conexion.SaveChanges();
        }
        public IEnumerable<Citum> GetAllReservas()
        {
            return conexion.Cita;
        }
        public void remove(int id)
        {
            var obj = (from tcit in conexion.Cita
                       where tcit.IdCita == id
                       select tcit).Single();

            conexion.Cita.Remove(obj);
            conexion.SaveChanges();

        }

        public IEnumerable<Citum> GetCitaEspecifica(string nomDoc) 
        {
            return (from tcit in conexion.Cita
                    where tcit.NomDoctor == nomDoc
                    select tcit);
        
        }
        public IEnumerable<Citum> GetCitaByDia(int IdDia, string apeDoc)
        {
            return (from tcit in conexion.Cita
                    where tcit.IdDia == IdDia
                    && tcit.NomDoctor == apeDoc
                    select tcit);
        }
        public IEnumerable<Citum> GetCitaByUser(int idUser)
        {
            return (from tcit in conexion.Cita
                    where tcit.IdUser == idUser
                    select tcit);
        }
        public void SendEmail(string from, string to, string subject, string body, string smtpServer, int smtpPort)
        {
            try
            {
                MailMessage message = new MailMessage(from, to, subject, body);
                SmtpClient smtpClient = new SmtpClient("bdpprueba@gmail.com", 587); // Reemplaza con el servidor SMTP adecuado y el puerto correspondiente

                // Configuración de las credenciales de autenticación si es necesario
                smtpClient.Credentials = new NetworkCredential("bdpprueba@gmail.com", "TodasMienten12");

                smtpClient.EnableSsl = true; // Si el servidor SMTP requiere SSL

                smtpClient.Send(message);

                Console.WriteLine("Correo electrónico enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
