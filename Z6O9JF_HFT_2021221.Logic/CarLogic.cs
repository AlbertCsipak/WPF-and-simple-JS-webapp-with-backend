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
            myRepository.Create(entity);
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
