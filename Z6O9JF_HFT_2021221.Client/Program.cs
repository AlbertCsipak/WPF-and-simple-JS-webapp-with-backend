using System;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext db = new();

            AdvancedLogic advanced = new(new BrandRepository(db),new CarRepository(db),new MechanicRepository(db),new OwnerRepository(db),
                new CarServiceRepository(db),new EngineRepository(db));

            var a1 = advanced.AVGPriceByBrands();
            db.SaveChanges();
            ;
        }
    }
}
