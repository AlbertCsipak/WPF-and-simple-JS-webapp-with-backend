using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface ICarServiceLogic
    {
        void Create(CarService entity);
        void Delete(int id);
        IEnumerable<CarService> GetAll();
        CarService Read(int id);
        void Update(CarService entity);
    }
}