using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand entity);
        void Delete(int id);
        IQueryable<Brand> GetAll();
        Brand Read(int id);
        void Update(Brand entity);
    }
}