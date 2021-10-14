using System;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Models;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Repository
{
    public class EngineRepository
    {
        MyDbContext dataBase;

        public EngineRepository(MyDbContext database)
        {
            this.dataBase = database;
        }

        public void Create(Engine entity)
        {
            dataBase.Engine.Add(entity);
            dataBase.SaveChanges();
        }

        public Engine Read(int id)
        {
            return dataBase.Engine.FirstOrDefault(entity => entity.EngineCode == id);
        }

        public IQueryable<Engine> GetAll()
        {
            return dataBase.Engine;
        }

        public void Delete(int id)
        {
            var entity = Read(id);
            dataBase.Engine.Remove(entity);
            dataBase.SaveChanges();
        }

        public void Update(Engine entity)
        {
            var entityToUpdate = Read(entity.EngineCode);
            entityToUpdate.BrandId = entity.BrandId;
            entityToUpdate.Displacement = entity.Displacement;
            entityToUpdate.EngineType = entity.EngineType;
            entityToUpdate.Power = entity.Power;

            dataBase.SaveChanges();
        }
    }
}
