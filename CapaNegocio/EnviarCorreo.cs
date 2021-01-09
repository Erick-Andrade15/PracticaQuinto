using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCrypto;
using System.Net.Mail;
using System.Net;

namespace CapaNegocio
{
    public class EnviarCorreo
    {
        public bool EnviarCorreoElectronico(string Remitente, string ContraseniaNueva, string Nombre)
        {
            string CorreoAdmin = "anaramsa05@gmail.com";
            string ContraseniaAdmin = "Anaramsa.7566";


            //CONFIGURACION SMTP 
            var smpt = new SmtpClient();
            {
                smpt.Host = "smtp.gmail.com";
                smpt.Port = 587;//25
                smpt.EnableSsl = true;
                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smpt.Credentials = new NetworkCredential(CorreoAdmin, ContraseniaAdmin);
                smpt.Timeout = 30000;
            }

            MailMessage msg = null;
            msg = new MailMessage("anaramsa05@gmail.com",
                   "" + Remitente + "", //Remitente
                   "Recuperacion de Contraseña en Anaramsa",//ASUNTO
                   "Hola " + Nombre + " Su nueva Contraseña para el ingreso en Anaramsa es: " + //MENSAJE
                   "<strong>" + ContraseniaNueva + "</strong>");

            msg.IsBodyHtml = true;

            try
            {
                smpt.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
                throw;
            }


            return true;

        }
    }
}
