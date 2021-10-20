using System;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.Data;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        AdvancedLogic advancedLogic;
        CarLogic carLogic;

        [SetUp]
        public void MockSetup()
        {
            var mockCarRepository =new Mock<ICarRepository>();

            Brand fakeBrand = new Brand();
            fakeBrand.BrandId = 1;
            fakeBrand.Name = "Audi";

            Engine fakeEngine = new Engine();
            fakeEngine.BrandId = fakeBrand.BrandId;
            fakeEngine.Displacement = 1788;
            fakeEngine.EngineType = Enums.EngineType.Petrol;
            fakeEngine.Power = 120;
            fakeEngine.EngineCode = 0123456;

            var cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "A3",
                        BrandId = fakeBrand.BrandId,
                        Brand = fakeBrand,
                        Engine = fakeEngine,
                        EngineCode = fakeEngine.EngineCode,
                        Vin = 1,
                        ServiceCost = 500
                    },
                    new Car()
                    {
                        Model = "Q6",
                        BrandId = fakeBrand.BrandId,
                        Brand = fakeBrand,
                        Engine = fakeEngine,
                        EngineCode = fakeEngine.EngineCode,
                        Vin = 2,
                        ServiceCost = 1000
                    }
                }.AsQueryable();

            mockCarRepository.Setup(car => car.GetAll()).Returns(cars);

            advancedLogic = new AdvancedLogic(mockCarRepository.Object);

            carLogic = new CarLogic(mockCarRepository.Object);
        }

        [Test]
        public void AVGServiceCostByBrandsTest()
        {
            var result = advancedLogic.AVGServiceCostByBrands();

            var expected = new List<KeyValuePair<string, double>>() { new KeyValuePair<string, double>("Audi", 750)};

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAllTest() 
        {
            var result = carLogic.GetAll();

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void CreateVinLengthTest() 
        {
            Car testCar = new();
            testCar.Vin = 31234678;

            Assert.Throws<ArgumentException>(() => carLogic.Create(testCar)); //stack#933613
        }

    }
}
