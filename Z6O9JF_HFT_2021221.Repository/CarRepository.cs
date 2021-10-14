using System;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Models;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Repository
{
    public class CarRepository
    {
        MyDbContext dataBase;
        public CarRepository(MyDbContext database)
        {
            this.dataBase = database;
        }
        public IQueryable<Car> GetAll()
        {
            return dataBase.Car;
        }
        public void Create(Car entity)
        {
            dataBase.Car.Add(entity);
            dataBase.SaveChanges();
        }
        public Car Read(int id)
        {
            return dataBase.Car.FirstOrDefault(entity => entity.Vin == id);
        }        
        public void Update(Car entity)
        {
            var entityToUpdate = Read(entity.Vin);
            entityToUpdate.MechanicId = entity.MechanicId;
            entityToUpdate.BrandId = entity.BrandId;
            entityToUpdate.OwnerId = entity.OwnerId;
            entityToUpdate.Model = entity.Model;
            entityToUpdate.BodyStyle = entity.BodyStyle;
            entityToUpdate.Color = entity.Color;
            entityToUpdate.EngineCode = entity.EngineCode;
            dataBase.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = Read(id);
            dataBase.Car.Remove(entity);
            dataBase.SaveChanges();
        }
    }
}
