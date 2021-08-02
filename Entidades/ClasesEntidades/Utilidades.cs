using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Utilidades
    {
        public string ObtenerClaveTemporal()
        {

            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }


            return contraseniaAleatoria;
        }

        public void EnviarCorreo(string Contraseña, string Correo)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Usuario"].ToString(), ConfigurationManager.AppSettings["Clave"].ToString());



                MailMessage mail = new MailMessage();
                mail.Subject = "Contrasena Sistema Registro Citas";
                mail.Body = "Su Contraseña de Acceso es: " + Contraseña;
                mail.From = new MailAddress(ConfigurationManager.AppSettings["Usuario"].ToString());
                mail.To.Add(Correo);


                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }

        }

        public bool EnviarCorreoGenerico(Correo Correo) {
            bool SeEnvioCorreo = false;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Usuario"].ToString(), ConfigurationManager.AppSettings["Clave"].ToString());

                MailMessage mail = new MailMessage();

                mail.Subject = Correo.Subject;
                mail.Body = Correo.Body;
                mail.From = new MailAddress(ConfigurationManager.AppSettings["Usuario"].ToString());
                mail.To.Add(Correo.To);
                //mail.Priority = MailPriority.High;

                smtp.Send(mail);
                SeEnvioCorreo = true;
            }
            catch (Exception ex)
            {

                
            }

            return SeEnvioCorreo;
        }



        public void EnviarCorreoColaboradores(string Contraseña, string Correo)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Colaboradores"].ToString(), ConfigurationManager.AppSettings["Clave"].ToString());



                MailMessage mail = new MailMessage();
                mail.Subject = "Contrasena Sistema Registro Citas";
                mail.Body = "Su Contraseña de Acceso es: " + Contraseña;
                mail.From = new MailAddress(ConfigurationManager.AppSettings["Colaboradores"].ToString());
                mail.To.Add(Correo);


                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }

        }




    }
}
