using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner entity);
        void Delete(int id);
        IEnumerable<Owner> GetAll();
        Owner Read(int id);
        void Update(Owner entity);
    }
}