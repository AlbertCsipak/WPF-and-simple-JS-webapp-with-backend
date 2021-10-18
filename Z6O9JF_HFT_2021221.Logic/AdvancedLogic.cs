﻿using System;
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
        public IEnumerable<KeyValuePair<string,double>> ServiceIncome()
        {
            return from car in carRepo.GetAll()
                   group car by car.Mechanic.CarService.Name into carg
                   select new KeyValuePair<string, double>(carg.Key, carg.Sum(entity => entity.ServiceCost));
        }
        public IEnumerable<KeyValuePair<string, List<Brand>>> CarBrandsInService()
        {
            var cars = carRepo.GetAll().AsEnumerable().GroupBy(car => car.Mechanic.CarService.Name);
            Dictionary<string, List<Brand>> services = new();

            foreach (var car in cars)
            {
                List<Brand> brands = new();
                foreach (var car1 in car)
                {
                    if (!brands.Contains(car1.Brand))
                    {
                        brands.Add(car1.Brand);
                    }
                }
                services.Add(car.Key, brands);
            }
            return services;
        }
        public IEnumerable<KeyValuePair<string, Dictionary<Enums.EngineType,int>>> MechanicEngineTypeCount() 
        {
            var mechanics = carRepo.GetAll().AsEnumerable().GroupBy(mechanic => mechanic.Mechanic.Name);
            Dictionary<string, Dictionary<Enums.EngineType,int>> mechanicDic = new();

            foreach (var mechanic in mechanics)
            {
                Dictionary<Enums.EngineType,int> engineType = new();
                int engineCount = 1;
                foreach (var car in mechanic)
                {
                    if (!engineType.ContainsKey(car.Engine.EngineType))
                    {
                        engineType.Add(car.Engine.EngineType,engineCount);
                    }
                    else
                    {
                        engineType[car.Engine.EngineType]++;
                    }
                }
                mechanicDic.Add(mechanic.Key, engineType);
            }
            return mechanicDic;
        }
        public IEnumerable<KeyValuePair<string, Dictionary<int, int>>> EveryCarWithMoreThan110HP()
        {
            var cars = carRepo.GetAll().AsEnumerable().GroupBy(car => car.Brand.Name);
            Dictionary<string, Dictionary<int, int>> outDic = new();

            foreach (var car in cars)
            {
                Dictionary<int, int> carDic = new();
                foreach (var car1 in car)
                {
                    if (!carDic.ContainsKey(car1.Vin) && car1.Engine.Power > 110)
                    {
                        carDic.Add(car1.Vin, car1.Engine.Power);
                    }
                }
                outDic.Add(car.Key, carDic);
            }
            return outDic;
        }
    }
}
