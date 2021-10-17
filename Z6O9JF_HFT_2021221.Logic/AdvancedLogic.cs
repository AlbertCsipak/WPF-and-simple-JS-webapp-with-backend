using System;
using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Models;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Logic
{
    public class AdvancedLogic
    {
        IBrandRepository brandRepo;
        ICarRepository carRepo;
        IMechanicRepository mechanicRepo;
        IOwnerRepository ownerRepo;
        ICarServiceRepository carServiceRepo;
        IEngineRepository engineRepo;

        public AdvancedLogic(IBrandRepository brandRepository, ICarRepository carRepository, IMechanicRepository mechanicRepository,
            IOwnerRepository ownerRepository, ICarServiceRepository carServiceRepository, IEngineRepository engineRepository)
        {
            this.brandRepo = brandRepository;
            this.carRepo = carRepository;
            this.mechanicRepo = mechanicRepository;
            this.ownerRepo = ownerRepository;
            this.carServiceRepo = carServiceRepository;
            this.engineRepo = engineRepository;
        }

        public IEnumerable<KeyValuePair<string, double>> AVGServiceCostByBrands()
        {
            return from car in carRepo.GetAll()
                   group car by car.Brand.Name into carg
                   select new KeyValuePair<string, double>(carg.Key, carg.Average(car => car.ServiceCost));
        }
        public IEnumerable<KeyValuePair<Enums.EngineType, int>> MostCommonEngineType()
        {
            return from engine in engineRepo.GetAll()
                   group engine by engine.EngineType into engineg
                   select new KeyValuePair<Enums.EngineType, int>(engineg.Key, engineg.Count());
        }
        public IEnumerable<KeyValuePair<int, double>> HorsePower()
        {
            return from car in carRepo.GetAll()
                   select new KeyValuePair<int, double>(car.Vin, car.Engine.Power);
        }
        public IEnumerable<KeyValuePair<string,double>> ServiceIncome()
        {
            return from car in carRepo.GetAll()
                   group car by car.Mechanic.CarService.Name into carg
                   select new KeyValuePair<string, double>(carg.Key, carg.Sum(entity => entity.ServiceCost));
        }
        public IEnumerable<KeyValuePair<string, List<Brand>>> CarBrandsInService()
        {
            var a1 = carRepo.GetAll().AsEnumerable().GroupBy(car => car.Mechanic.CarService.Name);

            List<Brand> brands = new();
            List<KeyValuePair<string, List<Brand>>> services = new();

            foreach (var item in a1)
            {
                foreach (var item1 in item)
                {
                    if (!brands.Contains(item1.Brand))
                    {
                        brands.Add(item1.Brand);
                    }
                }
                services.Add(new KeyValuePair<string, List<Brand>>(item.Key, brands));
                brands = null;
            }
            ;
            return services;
        }
    }
}
