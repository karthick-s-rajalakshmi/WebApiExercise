using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehiclelInformationCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendingMailController : ControllerBase
    {
       
        IConfiguration con = null;
        public SendingMailController(IConfiguration configuration)
        {
          
            con = configuration;
        }
       
        [HttpPost]
        public IActionResult Post([FromBody] SendingMailEntity val)
        {
            SmtpMailSender obj = new SmtpMailSender();
           
            val.FromAddress = con.GetSection("Address").Value;
            val.password = con.GetSection("password").Value;
            obj.SendEmail(val);
            return Ok();
        }


    }
}
