using System;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Models;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Repository
{
    public class BrandRepository
    {
        MyDbContext dataBase;
        public BrandRepository(MyDbContext database)
        {
            this.dataBase = database;
        }        
        public IQueryable<Brand> GetAll()
        {
            return dataBase.Brand;
        }
        public void Create(Brand entity)
        {
            dataBase.Brand.Add(entity);
            dataBase.SaveChanges();
        }
        public Brand Read(int id)
        {
            return dataBase.Brand.FirstOrDefault(entity => entity.BrandId == id);
        }
        public void Update(Brand entity)
        {
            var entityToUpdate = Read(entity.BrandId);
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Location = entity.Location;
            dataBase.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = Read(id);
            dataBase.Brand.Remove(entity);
            dataBase.SaveChanges();
        }
    }
}
