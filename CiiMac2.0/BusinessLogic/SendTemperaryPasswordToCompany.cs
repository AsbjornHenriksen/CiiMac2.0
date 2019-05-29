using Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SendTemperaryPasswordToCompany
    {
        public void SendPasswordToCompanyEmail(Company company, string temporaryPassword)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("kenneth84petersen@hotmail.com");
            message.To.Add(new MailAddress(company.Email));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "Password : " + temporaryPassword;
            smtp.Port = 587;
            smtp.Host = "smtp.live.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("kenneth84petersen@hotmail.com", "Dsl2403901");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

        }
         
            
     }
}
