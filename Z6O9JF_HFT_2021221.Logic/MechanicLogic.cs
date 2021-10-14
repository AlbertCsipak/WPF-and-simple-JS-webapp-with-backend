﻿using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class MechanicLogic
    {
        IMechanicRepository myRepository;
        public MechanicLogic(IMechanicRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Mechanic> GetAll()
        {
            return myRepository.GetAll();
        }
        public void Create(Mechanic entity)
        {
            myRepository.Create(entity);
        }
        public Mechanic Read(int id)
        {
            return myRepository.Read(id);
        }
        public void Update(Mechanic entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(int id)
        {
            myRepository.Delete(id);
        }
    }
}