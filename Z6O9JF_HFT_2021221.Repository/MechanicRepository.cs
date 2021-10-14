﻿using System;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Models;
using System.Linq;


namespace Z6O9JF_HFT_2021221.Repository
{
    public class MechanicRepository
    {
        MyDbContext dataBase;

        public MechanicRepository(MyDbContext database)
        {
            this.dataBase = database;
        }

        public void Create(Mechanic entity)
        {
            dataBase.Mechanic.Add(entity);
            dataBase.SaveChanges();
        }

        public Mechanic Read(int id)
        {
            return dataBase.Mechanic.FirstOrDefault(entity => entity.MechanicId == id);
        }

        public IQueryable<Mechanic> GetAll()
        {
            return dataBase.Mechanic;
        }

        public void Delete(int id)
        {
            var entity = Read(id);
            dataBase.Mechanic.Remove(entity);
            dataBase.SaveChanges();
        }

        public void Update(Mechanic entity)
        {
            var entityToUpdate = Read(entity.MechanicId);
            entityToUpdate.Name = entity.Name;
            entityToUpdate.ServiceId = entity.ServiceId;
            dataBase.SaveChanges();
        }
    }
}
