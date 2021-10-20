﻿using System;
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

            //ICarRepository carRepo = new CarRepository(db);

            //carRepo.Create(new Car()
            //{
            //    BodyStyle = Enums.BodyStyleEnum.Sedan,
            //    BrandId = 1,
            //    Color = Enums.ColorEnum.Red,
            //    EngineCode = 5123123,
            //    MechanicId = 1,
            //    OwnerId = 1,
            //    Model = "anyad",
            //    ServiceCost = 1500
            //});
            //var a2 = carRepo.GetAll();

            AdvancedLogic advanced = new(new CarRepository(db));

            var a1 = advanced.AVGServiceCostByBrands();

            var a4 = advanced.ServiceIncome();

            var a5 = advanced.CarBrandsInService();

            var a6 = advanced.MechanicEngineTypeCount();

            var a7 = advanced.EveryCarWithMoreThan110HP();
            ;
        }
    }
}
