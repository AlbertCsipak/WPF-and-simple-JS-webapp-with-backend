using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public interface IEngineRepository
    {
        void Create(Engine entity);
        void Delete(int id);
        IQueryable<Engine> GetAll();
        Engine Read(int id);
        void Update(Engine entity);
    }
}