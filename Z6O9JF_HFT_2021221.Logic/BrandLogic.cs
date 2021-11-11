using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.Repository;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository myRepository;
        public BrandLogic(IBrandRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Brand> GetAll()
        {
            return myRepository.GetAll();
        }
        public void Create(Brand entity)
        {
            if (entity.BrandId < 0)
            {
                throw new ArgumentException("Incorrect BrandId");
            }
            else
            {
                myRepository.Create(entity);
            }
        }
        public Brand Read(int id)
        {
            return myRepository.Read(id);
        }
        public void Update(Brand entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(int id)
        {
            myRepository.Delete(id);
        }
    }
}
