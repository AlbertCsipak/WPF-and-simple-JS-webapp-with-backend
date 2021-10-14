using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface IMechanicLogic
    {
        void Create(Mechanic entity);
        void Delete(int id);
        IEnumerable<Mechanic> GetAll();
        Mechanic Read(int id);
        void Update(Mechanic entity);
    }
}