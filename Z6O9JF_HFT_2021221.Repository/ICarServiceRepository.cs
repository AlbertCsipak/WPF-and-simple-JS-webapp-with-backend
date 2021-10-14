using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public interface ICarServiceRepository
    {
        void Create(CarService entity);
        void Delete(int id);
        IQueryable<CarService> GetAll();
        CarService Read(int id);
        void Update(CarService entity);
    }
}