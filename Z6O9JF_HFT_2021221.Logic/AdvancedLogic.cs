using System;
using System.Collections.Generic;
using System.Collections;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class AdvancedLogic : IAdvancedLogic
    {
        ICarRepository carRepo;
        IBrandRepository brandRepo;
        IMechanicRepository mechanicRepo;
        IOwnerRepository ownerRepo;
        ICarServiceRepository carServiceRepo;
        IEngineRepository engineRepo;

        public AdvancedLogic(ICarRepository carRepository, IBrandRepository brandRepository, IMechanicRepository mechanicRepository,
            IOwnerRepository ownerRepository, ICarServiceRepository carServiceRepository, IEngineRepository engineRepository)
        {
            this.carRepo = carRepository;
            this.brandRepo = brandRepository;
            this.mechanicRepo = mechanicRepository;
            this.ownerRepo = ownerRepository;
            this.carServiceRepo = carServiceRepository;
            this.engineRepo = engineRepository;
        }

        public IEnumerable<KeyValuePair<string,double>> AVGServiceCostByBrands()
        {
            return from x in carRepo.GetAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.ServiceCost));

        }
        public IEnumerable<KeyValuePair<string, int>> ServiceIncome()
        {
            return from x in carServiceRepo
                    .GetAll()
                    .AsEnumerable()
                   group x by x.Name into g
                   select new KeyValuePair<string, int>(g.Key, g.SelectMany(t => t.Mechanics).SelectMany(x => x.Cars).Sum(v => v.ServiceCost));
        }
        public IEnumerable<KeyValuePair<string,List<string>>> CarBrandsInService()
        {
            return from x in carServiceRepo
                   .GetAll()
                   .AsEnumerable()
                   group x by x.Name into g
                   select new KeyValuePair<string, List<string>>(g.Key, g.SelectMany(t=>t.Mechanics).SelectMany(t=>t.Cars).Select(t=>t.Brand.Name).ToList() );
        }
        public IEnumerable<KeyValuePair<string,List<Enums.EngineType>>> MechanicEngineTypes()
        {
            return from x in mechanicRepo
                .GetAll()
                .AsEnumerable()
                   group x by x.Name into g
                   select new KeyValuePair<string, List<Enums.EngineType>>(g.Key, g.SelectMany(y => y.Cars.Select(x => x.Engine.EngineType)).Distinct().ToList());

        }
        public IEnumerable<KeyValuePair<string, List<Car>>> OwnersAndTheirStrongestCar()
        {
            return from x in ownerRepo
                .GetAll()
                .AsEnumerable()
                   group x by x.Name into g
                   select new KeyValuePair<string, List<Car>>(g.Key, g.SelectMany(t => t.Cars).OrderByDescending(t=>t.Engine.Power).Take(1).ToList());
        }
    }
}
