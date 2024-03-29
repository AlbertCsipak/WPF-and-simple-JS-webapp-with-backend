﻿using System.Linq;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public class CarServiceRepository : ICarServiceRepository
    {
        MyDbContext dataBase;
        public CarServiceRepository(MyDbContext database)
        {
            this.dataBase = database;
        }
        public IQueryable<CarService> GetAll()
        {
            return dataBase.Service;
        }
        public void Create(CarService entity)
        {
            dataBase.Service.Add(entity);
            dataBase.SaveChanges();
        }
        public CarService Read(int id)
        {
            return dataBase.Service.FirstOrDefault(entity => entity.TaxNumber == id);
        }
        public void Update(CarService entity)
        {
            var entityToUpdate = Read(entity.TaxNumber);
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Location = entity.Location;
            dataBase.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = Read(id);
            dataBase.Service.Remove(entity);
            dataBase.SaveChanges();
        }
    }
}
