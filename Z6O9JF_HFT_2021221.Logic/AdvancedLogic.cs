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

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from car in carRepo.GetAll() group car by car.Brand.Name into carg 
                   select new KeyValuePair<string, double> (carg.Key, carg.Average(car => car.ServiceCost));
        }
    }
}
