using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class SendingMailEntity
    {
        public string FromAddress { get; set; }

        public string password { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public string ToAddress { get; set; }       
    }
}
