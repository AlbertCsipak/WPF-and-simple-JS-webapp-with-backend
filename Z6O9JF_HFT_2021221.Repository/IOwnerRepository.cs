using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public interface IOwnerRepository
    {
        void Create(Owner entity);
        void Delete(int id);
        IQueryable<Owner> GetAll();
        Owner Read(int id);
        void Update(Owner entity);
    }
}