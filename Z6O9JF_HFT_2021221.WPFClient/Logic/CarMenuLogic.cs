using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class CarMenuLogic : ICarMenuLogic
    {
        RestCollection<Car> cars;
        IMessenger messenger;
        public CarMenuLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }
        public void Setup(RestCollection<Car> cars) { this.cars = cars; }
        public void Add()
        {
            Car car = new Car();

            cars.Add(car);
        }
        public void Edit(Car car)
        {

        }
        public void Remove(Car car)
        {
            cars.Delete(car.Vin);
        }
    }
}
