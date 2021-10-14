using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand entity);
        void Delete(int id);
        IEnumerable<Brand> GetAll();
        Brand Read(int id);
        void Update(Brand entity);
    }
}