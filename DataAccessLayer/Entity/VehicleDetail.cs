using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
  public  class VehicleDetail
    {
        public int vehicleId { get; set; }
        public string vehicleName { get; set; }
        public string  vehicleNumber { get; set; }
        public long       InsuranceNumber { get; set; }
        public long   DriverContactNumber { get; set; }
        public DateTime FCdate { get; set; }
        public string OwnerName { get; set; }
    }
}
