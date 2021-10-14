using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public interface ICarRepository
    {
        void Create(Car entity);
        void Delete(int id);
        IQueryable<Car> GetAll();
        Car Read(int id);
        void Update(Car entity);
    }
}