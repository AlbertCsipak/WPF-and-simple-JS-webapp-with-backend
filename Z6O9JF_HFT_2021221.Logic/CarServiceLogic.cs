using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class CarServiceLogic
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
            myRepository.Create(entity);
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
