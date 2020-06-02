using Dashboard_MK4.Models.V2_Models;
using Dashboard_MK4.Models.V2_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_MK4.Models.V2_DataManager
{
    public class Vehicle_Manager : IVehicleDataRepository<Vehicle>
    {
        readonly Vehicle_Context _vehicle_Context;
        public Vehicle_Manager(Vehicle_Context vehicle_Context)
        {
            _vehicle_Context = vehicle_Context;
        }

        public void Add(Vehicle entity)
        {
            _vehicle_Context.Vehicles.Add(entity);
            _vehicle_Context.SaveChanges();
        }

        public void Delete(Vehicle entity)
        {
            _vehicle_Context.Vehicles.Remove(entity);
            _vehicle_Context.SaveChanges();
        }

        public Vehicle Get(Guid id)
        {
            return _vehicle_Context.Vehicles.FirstOrDefault(e => e.Vehicle_ID == id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicle_Context.Vehicles.ToList();
        }

        public void Update(Vehicle dbEntity, Vehicle entity)
        {
            dbEntity.CC = entity.CC;
            dbEntity.Engine_Number = entity.Engine_Number;
            dbEntity.Make = entity.Make;
            dbEntity.Mileage = entity.Mileage;
            dbEntity.REG = entity.REG;
            dbEntity.VIN = entity.VIN;
            dbEntity.Year = entity.Year;
            _vehicle_Context.SaveChanges();
        }
    }
}
