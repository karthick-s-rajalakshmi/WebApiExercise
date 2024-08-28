using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public  class SendingMail
    {
     
        public void FileLog()
        {
            string file = $"FileForWebAPI_{DateTime.Now.ToString("yyyy-MM-dd")}.txt";

            try
            {

                Send();
                StreamWriter sw = new StreamWriter($"D:{file}.txt", false);
                sw.WriteLine($"Succefully sent Mail in{DateTime.Now.ToString("yyyy-MM-dd")} ");
                sw.Close();

            }
            catch (Exception e)
            {

                StreamWriter sw1 = new StreamWriter($"D:{file}.txt", false);
                sw1.WriteLine(e.StackTrace);
                sw1.Close();
            }

        }
        private void Send()
        {
            
            SendEmail(FromAddressMethod(), Password());

        }
        public string toAddress { get; set; }
       
        private void SendEmail(string fromAddress, string password)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)

            };

            
          

            try
            {
                email.Send(fromAddress, ToAddressMethod(), subject, body);   
            }
            catch (SmtpException e)
            {
                throw;
            }

        }
        public string ToAddress { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

       public  string Address { get; set; }
        public string password { get; set; }
        public void FromAddressDetail(string Address,string password)
        {
            this.Address = Address;
            this.password = password;
        }

        public void Detail(SendingMailEntity obj)
        {
            // SendingMailEntity obj = new SendingMailEntity();
            ToAddress = obj.ToAddress;
            subject = obj.Subject;
            body = obj.Body;

        }
        public string FromAddressMethod()
        {
            return this.Address;
        }

        public string ToAddressMethod()
        {
            return ToAddress;
        }

        public string Password()
        {
            return this.password;
        }

    }
}
