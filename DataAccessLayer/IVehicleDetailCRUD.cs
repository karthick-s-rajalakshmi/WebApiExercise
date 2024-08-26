using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IVehicleDetailCRUD
    {
        public void DeleteVehicleRecord(long VehicleId);
        public VehicleDetail SelectVehicleDetailByVehicleName(string username);
        public List<VehicleDetail> SelectALLVehicleInformation();
        public void UpdateVehileDetail(VehicleDetail reg);
        public void RegisterVehicle(VehicleDetail reg);
    }
}
