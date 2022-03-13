using Microsoft.Toolkit.Mvvm.Messaging;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Services;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class CarMenuLogic : ICarMenuLogic
    {
        RestCollection<Car> cars;
        IMessenger messenger;
        ICarCreatorService CarCreatorService;
        public CarMenuLogic(IMessenger messenger, ICarCreatorService carCreatorService)
        {
            this.messenger = messenger;
            this.CarCreatorService = carCreatorService;
        }
        public void Setup(RestCollection<Car> cars) { this.cars = cars; }
        public void Add()
        {
            Car car = new Car();
            CarCreatorService.Create(car);
            if (car != null)
            {
                cars.Add(car);
            }
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
