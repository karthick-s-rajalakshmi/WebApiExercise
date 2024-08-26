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
        public IEnumerable<VehicleDetail> Get()
        {
            return objCrud.SelectALLVehicleInformation();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{username}")]
        public VehicleDetail Get(string username)
        {
            return objCrud.SelectVehicleDetailByVehicleName(username);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post( VehicleDetail value)
        { 
            objCrud.RegisterVehicle(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] VehicleDetail value)
        {
            objCrud.UpdateVehileDetail(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objCrud.DeleteVehicleRecord(id);
        }
    }
}
