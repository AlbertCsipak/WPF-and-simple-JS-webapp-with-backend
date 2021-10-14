using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        void Create(Car entity);
        void Delete(int id);
        IEnumerable<Car> GetAll();
        Car Read(int id);
        void Update(Car entity);
    }
}