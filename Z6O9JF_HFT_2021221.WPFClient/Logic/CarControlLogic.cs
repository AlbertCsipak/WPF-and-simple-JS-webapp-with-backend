using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class CarControlLogic : ICarControlLogic
    {
        RestCollection<Car> cars;
        RestService restService = new("http://localhost:11111/");
        public IList<int> MechanicIds { get { return restService.Get<Mechanic>("mechanic").Select(t => t.MechanicId).ToList(); } }
        public CarControlLogic() { }
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
        }
        public void Edit(Car car)
        {
            cars.Update(car);
        }
        public void Remove(Car car)
        {
            cars.Delete(car.Vin);
        }
    }
}
