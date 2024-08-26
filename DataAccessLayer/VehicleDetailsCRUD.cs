using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using DataAccessLayer.Entity;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
   public  class VehicleDetailsCRUD:IVehicleDetailCRUD
    {
        string connectionString = "server=desktop-blbgehj\\sqlexpress;database=VehicleInformation;user Id =sa;password=Anaiyaan@123;";
        SqlConnection con = null;
        public VehicleDetailsCRUD(IConfiguration configuration)
        {
          connectionString=  configuration.GetConnectionString("DbConnection");
            con = new SqlConnection(connectionString);

        }

        /*
        public void DeleteVehicleRecord(long VehicleId);
        public VehicleDetail SelectVehicleDetailByVehicleName(string username);
        public List<VehicleDetail> SelectALLVehicleInformation();
        public void UpdateVehileDetail(VehicleDetail reg);
        public void RegisterVehicle(VehicleDetail reg);
         
         */

        public void RegisterVehicle(VehicleDetail reg)
        {
            try
            {
                var insertQuery = $"exec insertData_vehcileInformation '{reg.vehicleName}','{reg.vehicleNumber}'," +
                    $"{reg.InsuranceNumber},{reg.DriverContactNumber},'{reg.FCdate}','{reg.OwnerName}' ";
                
                con.Open();
                con.Execute(insertQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateVehileDetail(VehicleDetail reg)
        {
            try
            {
                var updateQuery = $"exec UpdateValue_WhereVehcileId {reg.vehicleId},'{reg.vehicleName}','{reg.vehicleNumber}'," +
                    $"{reg.InsuranceNumber},{reg.DriverContactNumber},'{reg.FCdate}','{reg.OwnerName}' ";

                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public List<VehicleDetail> SelectALLVehicleInformation()
        {
            try
            {
                var selectQuery = $" exec SelectAllUser_VehicleInformation";
                con.Open();
                List<VehicleDetail> result = con.Query<VehicleDetail>(selectQuery).ToList();
                con.Close();
               
               
                return result;
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public VehicleDetail SelectVehicleDetailByVehicleName(string username)
        {
            try
            {
                var selectQuery = $"select_VehicleBy_VehicleName '{username}'";
                con.Open();
                VehicleDetail result = con.QueryFirstOrDefault<VehicleDetail>(selectQuery);
                con.Close();
               
             
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void DeleteVehicleRecord(long VehicleId)
        {
            try
            {
                var DeleteQuery = $"exec DeleteValue_WhereVehcileId {VehicleId}";
                con.Open();
                con.Execute(DeleteQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
