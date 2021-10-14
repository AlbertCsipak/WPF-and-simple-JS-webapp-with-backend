using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class CarLogic
    {
        ICarRepository myRepository;
        public CarLogic(ICarRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Car> GetAll()
        {
            return myRepository.GetAll();
        }
        public void Create(Car entity)
        {
            if (entity.MechanicId<1)
            {
                throw new ArgumentException("Incorrect MechanicId");
            }
            else if (entity.OwnerId<1)
            {
                throw new ArgumentException("Incorrect OwnerId");
            }
            else if (entity.Vin.ToString().Length!=9)
            {
                throw new ArgumentException("Incorrect Vehicle Identification Number");
            }
            else if (entity.BrandId<1)
            {
                throw new ArgumentException("Incorrect BrandId");
            }
            else if (entity.EngineCode.ToString().Length!=7)
            {
                throw new ArgumentException("Incorrect EngineCode");
            }
            else
            {
                myRepository.Create(entity);
            }
        }
        public Car Read(int id)
        {
            return myRepository.Read(id);
        }
        public void Update(Car entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(int id)
        {
            myRepository.Delete(id);
        }
    }
}
