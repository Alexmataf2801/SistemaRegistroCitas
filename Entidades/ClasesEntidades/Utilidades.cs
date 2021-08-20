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
                mail.IsBodyHtml = true;
                mail.Subject = "Contrasena Sistema Registro Citas";
                String BODY = string.Format(@" 
                                <html>                                                      
                                </head>
 <body marginheight=""0"" topmargin=""0"" marginwidth=""0"" style=""margin: 0px; background-color: #f2f3f8;"" leftmargin=""0"">
   
    <table cellspacing=""0"" border=""0"" cellpadding=""0"" width=""100%"" bgcolor=""#f2f3f8"" style=""font-family: Open Sans,sans-serif;"">
        <tr>
            <td>
                <table style=""background-color: #f2f3f8; max-width:670px;  margin:0 auto;"" width=""100%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width=""95%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);"">
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style=""padding:0px 35px;"">
                                        <h1 style=""color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family: Rubik,sans-serif;"">Se ha registrado exitosamente</h1>
                                        <span style=""display:inline-block; vertical-align:middle; margin:29px 0px 26px; border-bottom:1px solid #cecece; width:100px;""></span>
                                        <p style=""color:#455056; font-size:15px;line-height:24px; margin:0;"">                                            
                                            Se ha generado una contraseña aleatoria para mayor seguridad.
                                            Porfavor ingrese al sistema y realice el cambio de su contraseña por su seguridad.
                                        </p>
                                        <p style=""background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;"">{0}</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style=""text-align:center;"">
                            <p style=""font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0px 0px 0px;"">Copyright &copy; {1} </p>
                        </td>
                    </tr>
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</body>
                     <body> 
                                ", Contraseña, DateTime.Now.Year);
                mail.Body = BODY;
                    //"Su Contraseña de Acceso es: " + Contraseña;
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
                mail.IsBodyHtml = true;
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
