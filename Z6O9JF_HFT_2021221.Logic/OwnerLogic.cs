using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.Repository;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class OwnerLogic : IOwnerLogic
    {
        IOwnerRepository myRepository;
        public OwnerLogic(IOwnerRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Owner> GetAll()
        {
            return myRepository.GetAll();
        }
        public void Create(Owner entity)
        {
            if (entity.OwnerId < 0)
            {
                throw new ArgumentException("Incorrect OwnerId");
            }
            else
            {
                myRepository.Create(entity);
            }
        }
        public Owner Read(int id)
        {
            return myRepository.Read(id);
        }
        public void Update(Owner entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(int id)
        {
            myRepository.Delete(id);
        }
    }
}
