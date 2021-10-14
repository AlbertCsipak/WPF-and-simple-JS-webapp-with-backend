using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Logic
{
    public interface IEngineLogic
    {
        void Create(Engine entity);
        void Delete(int id);
        IEnumerable<Engine> GetAll();
        Engine Read(int id);
        void Update(Engine entity);
    }
}