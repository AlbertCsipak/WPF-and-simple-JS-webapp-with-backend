using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public interface IMechanicRepository
    {
        void Create(Mechanic entity);
        void Delete(int id);
        IQueryable<Mechanic> GetAll();
        Mechanic Read(int id);
        void Update(Mechanic entity);
    }
}