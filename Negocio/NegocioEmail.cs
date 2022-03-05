using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Negocio
{
    public class NegocioEmail
    {
        private MailMessage email;
        private SmtpClient server;

        public NegocioEmail()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("remerasfloripais@gmail.com", "floripais123");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceprogramacioniii.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;

        }

        public void armarCorreoContacto(string emailContacto, string asunto, string cuerpo)
        {
            string emailDestino = "remerasfloripais@gmail.com";
            email = new MailMessage();
            email.From = new MailAddress(emailContacto);
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = "De: " + emailContacto + "\n\n" + cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}