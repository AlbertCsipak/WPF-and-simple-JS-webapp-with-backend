using System;
using Z6O9JF_HFT_2021221.Repository;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Models;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Z6O9JF_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        IAdvancedLogic advancedLogic;
        ICarLogic carLogic;

        [SetUp]
        public void MockSetup()
        {
            var mockCarRepository = new Mock<ICarRepository>();
            var mockBrandRepository = new Mock<IBrandRepository>();
            var mockCarServiceRepository = new Mock<ICarServiceRepository>();
            var mockMechanicRepository = new Mock<IMechanicRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            var mockEngineRepository = new Mock<IEngineRepository>();

            var carServices = new List<CarService>()
            {
                new CarService()
                {
                    Name = "Service1",
                    TaxNumber = 1111
                },
                new CarService()
                {
                    Name = "Service2",
                    TaxNumber = 2222
                }
            }.AsQueryable();

            var brands = new List<Brand>()
            {
                new Brand()
                {
                    BrandId = 1,
                    Name = "Audi"
                },
                new Brand()
                {
                    BrandId = 2,
                    Name = "Bmw"
                },

            }.AsQueryable();

            var engines = new List<Engine>()
            {
                new Engine()
                {
                    BrandId = brands.ElementAt(0).BrandId,
                    Brand = brands.ElementAt(0),
                    Displacement = 1788,
                    EngineType = Enums.EngineType.Petrol,
                    Power =  120,
                    EngineCode = 0123456
                },
                new Engine()
                {
                    BrandId = brands.ElementAt(1).BrandId,
                    Brand = brands.ElementAt(1),
                    Displacement = 1988,
                    EngineType = Enums.EngineType.Gasoline,
                    Power =  100,
                    EngineCode = 6543210
                }
            }.AsQueryable();

            var cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "A3",
                        BrandId = brands.ElementAt(0).BrandId,
                        Brand = brands.ElementAt(0),
                        Engine =  engines.ElementAt(0),
                        EngineCode =  engines.ElementAt(0).EngineCode,
                        Vin = 1,
                        ServiceCost = 500
                    },
                    new Car()
                    {
                        Model = "Q6",
                        BrandId = brands.ElementAt(0).BrandId,
                        Brand = brands.ElementAt(0),
                        Engine =  engines.ElementAt(0),
                        EngineCode =  engines.ElementAt(0).EngineCode,
                        Vin = 2,
                        ServiceCost = 1000
                    },
                    new Car()
                    {
                        Model = "X5",
                        BrandId = brands.ElementAt(1).BrandId,
                        Brand = brands.ElementAt(1),
                        Engine =  engines.ElementAt(1),
                        EngineCode =  engines.ElementAt(1).EngineCode,
                        Vin = 3,
                        ServiceCost = 300
                    },
                    new Car()
                    {
                        Model = "M3",
                        BrandId = brands.ElementAt(1).BrandId,
                        Brand = brands.ElementAt(1),
                        Engine =  engines.ElementAt(1),
                        EngineCode =  engines.ElementAt(1).EngineCode,
                        Vin = 4,
                        ServiceCost = 600
                    }
                }.AsQueryable();

            var owners = new List<Owner>()
            {
                new Owner()
                {
                    Name = "Béla",
                    OwnerId = 1,
                    Cars = {cars.ElementAt(0),cars.ElementAt(2) }
                },
                new Owner()
                {
                    Name = "Ádi",
                    OwnerId = 2,
                    Cars = {cars.ElementAt(1),cars.ElementAt(3) }
                }
            }.AsQueryable();

            var mechanics = new List<Mechanic>()
            {
                new Mechanic()
                {
                    Name = "Géza",
                    MechanicId = 1,
                    CarService = carServices.ElementAt(0),
                    ServiceId = carServices.ElementAt(0).TaxNumber,
                    Cars = {cars.ElementAt(0),cars.ElementAt(2) }
                },
                new Mechanic()
                {
                    Name = "Szabi",
                    MechanicId = 2,
                    CarService = carServices.ElementAt(1),
                    ServiceId = carServices.ElementAt(1).TaxNumber,
                    Cars = {cars.ElementAt(1),cars.ElementAt(3) }
                }
            }.AsQueryable();

            //Brands
            brands.ElementAt(0).Cars.Add(cars.ElementAt(0));
            brands.ElementAt(0).Cars.Add(cars.ElementAt(1));

            brands.ElementAt(1).Cars.Add(cars.ElementAt(2));
            brands.ElementAt(1).Cars.Add(cars.ElementAt(3));

            brands.ElementAt(0).Engines.Add(engines.ElementAt(0));

            brands.ElementAt(1).Engines.Add(engines.ElementAt(1));

            //Engines
            engines.ElementAt(0).Cars.Add(cars.ElementAt(0));
            engines.ElementAt(0).Cars.Add(cars.ElementAt(1));

            engines.ElementAt(1).Cars.Add(cars.ElementAt(2));
            engines.ElementAt(1).Cars.Add(cars.ElementAt(3));

            //Services
            carServices.ElementAt(0).Mechanics.Add(mechanics.ElementAt(0));

            carServices.ElementAt(1).Mechanics.Add(mechanics.ElementAt(1));

            //RepoSetup
            mockCarRepository.Setup(car => car.GetAll()).Returns(cars);
            mockEngineRepository.Setup(engine =>engine.GetAll()).Returns(engines);
            mockBrandRepository.Setup(brand => brand.GetAll()).Returns(brands);
            mockMechanicRepository.Setup(mechanic=>mechanic.GetAll()).Returns(mechanics);
            mockOwnerRepository.Setup(owner => owner.GetAll()).Returns(owners);
            mockCarServiceRepository.Setup(carservice => carservice.GetAll()).Returns(carServices);

            advancedLogic = new AdvancedLogic(mockCarRepository.Object,mockBrandRepository.Object,mockMechanicRepository.Object,
                mockOwnerRepository.Object,mockCarServiceRepository.Object,mockEngineRepository.Object);

            carLogic = new CarLogic(mockCarRepository.Object);
        }
        [Test]
        public void CarBrandsInServiceTest()
        {

            var result = advancedLogic.CarBrandsInService();
            ;
            var expected = new List<KeyValuePair<string, double>>() { new KeyValuePair<string, double>("Audi", 750) };


        }
        [Test]
        public void EveryCarWithMoreThan110HPByBrandTest()
        {
            var result = advancedLogic.OwnersAndTheirStrongestCar();
            ;
            var expected = new List<KeyValuePair<string, double>>() { new KeyValuePair<string, double>("Audi", 750) };


        }
        [Test]
        public void MechanicEngineTypesTest()
        {
            var result = advancedLogic.MechanicEngineTypes();
            ;
            var expected = new List<KeyValuePair<string, double>>() { new KeyValuePair<string, double>("Audi", 750) };


        }
        [Test]
        public void ServiceIncomeTest()
        {
            var result = advancedLogic.ServiceIncome();
            ;
            var expected = new List<KeyValuePair<string, double>>() { new KeyValuePair<string, double>("Audi", 750) };


        }

        [Test]
        public void AVGServiceCostByBrandsTest()
        {
            var result = advancedLogic.AVGServiceCostByBrands();
            
            var expected = new List<KeyValuePair<string, double>>() { new KeyValuePair<string, double>("Audi", 750), new KeyValuePair<string, double>("Bmw", 450)}; 

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAllTest()
        {
            var result = carLogic.GetAll();

            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public void CarLogicCreateExceptionTest()
        {
            Car testCar = new();
            testCar.Vin = 5;

            Assert.That(() => { carLogic.Create(testCar); }, Throws.Exception); //stack#933613
            
        }
    }
}
