using System.Linq;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        MyDbContext dataBase;
        public OwnerRepository(MyDbContext database)
        {
            this.dataBase = database;
        }
        public IQueryable<Owner> GetAll()
        {
            return dataBase.Owner;
        }
        public void Create(Owner entity)
        {
            dataBase.Owner.Add(entity);
            dataBase.SaveChanges();
        }
        public Owner Read(int id)
        {
            return dataBase.Owner.FirstOrDefault(entity => entity.OwnerId == id);
        }
        public void Update(Owner entity)
        {
            var entityToUpdate = Read(entity.OwnerId);
            entityToUpdate.Name = entity.Name;
            dataBase.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = Read(id);
            dataBase.Owner.Remove(entity);
            dataBase.SaveChanges();
        }
    }
}
