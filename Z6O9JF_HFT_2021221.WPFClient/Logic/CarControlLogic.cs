using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class CarControlLogic : ICarControlLogic
    {
        RestCollection<Car> cars;
        RestService restService = new("http://localhost:11111/");
        IMessenger messenger;
        public IList<int> MechanicIds { get { return restService.Get<Mechanic>("mechanic").Select(t => t.MechanicId).ToList(); } }
        public IList<int> BrandIds { get { return restService.Get<Brand>("brand").Select(t => t.BrandId).ToList(); } }

        public CarControlLogic(IMessenger messenger) { this.messenger = messenger; }

        public void Setup(RestCollection<Car> cars)
        {
            this.cars = cars;
        }

        public void Add(Car car)
        {
            Car newCar = new Car()
            {
                BrandId = car.BrandId,
                ServiceCost = car.ServiceCost,
                EngineCode = car.EngineCode,
                MechanicId = car.MechanicId,
                OwnerId = car.OwnerId,
                Model = car.Model,
                Mechanic = car.Mechanic,
                BodyStyle = car.BodyStyle,
                Brand = car.Brand,
                Color = car.Color,
                Engine = car.Engine,
                Owner = car.Owner
            };
            cars.Add(newCar);
            messenger.Send("msg", "BasicChannel");
        }

        public void Edit(Car car)
        {
            cars.Update(car);
            messenger.Send("msg", "BasicChannel");
        }
        public void Remove(Car car)
        {
            cars.Delete(car.Vin);
            messenger.Send("msg", "BasicChannel");
        }
    }
}
