using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehiclelInformationCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCRUDController : ControllerBase
    {

        IVehicleDetailCRUD objCrud = null;
        public VehicleCRUDController(IVehicleDetailCRUD vehicleDetail)
        {
           
            objCrud= vehicleDetail;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(objCrud.SelectALLVehicleInformation());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            return Ok(objCrud.SelectVehicleDetailByVehicleName(username));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post( VehicleDetail value)
        { 
            objCrud.RegisterVehicle(value);
           return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] VehicleDetail value)
        {
            objCrud.UpdateVehileDetail(value);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            objCrud.DeleteVehicleRecord(id);
            return Ok();
        }
    }
}
