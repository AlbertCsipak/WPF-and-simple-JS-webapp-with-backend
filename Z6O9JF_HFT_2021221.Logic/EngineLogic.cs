using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class EngineLogic
    {
        IEngineRepository myRepository;
        public EngineLogic(IEngineRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Engine> GetAll()
        {
            return myRepository.GetAll();
        }
        public void Create(Engine entity)
        {
            myRepository.Create(entity);
        }
        public Engine Read(int id)
        {
            return myRepository.Read(id);
        }
        public void Update(Engine entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(int id)
        {
            myRepository.Delete(id);
        }
    }
}
