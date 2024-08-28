using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public  class SmtpMailSender
    {
        public void SendEmail(SendingMailEntity value)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(value.FromAddress, value.password)

            };




            try
            {
                email.Send(value.FromAddress, value.ToAddress, value.Subject, value.Body);
            }
            catch (SmtpException e)
            {
                throw;
            }

        }
    }
}
