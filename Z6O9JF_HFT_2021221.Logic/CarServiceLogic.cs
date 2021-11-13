using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.Repository;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class CarServiceLogic : ICarServiceLogic
    {
        ICarServiceRepository myRepository;
        public CarServiceLogic(ICarServiceRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<CarService> GetAll()
        {
            return myRepository.GetAll();
        }
        public void Create(CarService entity)
        {
            if (entity.TaxNumber < 0)
            {
                throw new ArgumentException("Incorrect Tax Number");
            }
            else
            {
                myRepository.Create(entity);
            }
        }
        public CarService Read(int id)
        {
            return myRepository.Read(id);
        }
        public void Update(CarService entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(int id)
        {
            myRepository.Delete(id);
        }
    }
}
