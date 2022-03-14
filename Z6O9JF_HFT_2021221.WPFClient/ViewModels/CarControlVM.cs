using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Logic;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class CarControlVM : ObservableRecipient
    {
        ICarControlLogic carMenuLogic;
        public RestCollection<Car> Cars { get; set; }
        public ObservableCollection<int> MechanicIds { get { return new(carMenuLogic.MechanicIds); } }

        private Car selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Brand = value.Brand,
                        Owner = value.Owner,
                        Mechanic = value.Mechanic,
                        BodyStyle = value.BodyStyle,
                        Engine = value.Engine,
                        Vin = value.Vin,
                        Color = value.Color,
                        Model = value.Model,
                        ServiceCost = value.ServiceCost,
                        BrandId = value.BrandId,
                        EngineCode = value.EngineCode,
                        MechanicId = value.MechanicId,
                        OwnerId = value.OwnerId
                    };
                    OnPropertyChanged();
                    (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                    (EditCommand as RelayCommand).NotifyCanExecuteChanged();
                    (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                return
                    (bool)DependencyPropertyDescriptor
                    .FromProperty(DesignerProperties.
                    IsInDesignModeProperty,
                    typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }
        public CarControlVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<ICarControlLogic>()) { }
        public CarControlVM(ICarControlLogic carMenuLogic)
        {
            this.carMenuLogic = carMenuLogic;
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:11111/", "car", "hub");
                carMenuLogic.Setup(Cars);
            }

            AddCommand = new RelayCommand(() => carMenuLogic.Add(SelectedCar), () => SelectedCar != null);
            RemoveCommand = new RelayCommand(() => carMenuLogic.Remove(SelectedCar), () => SelectedCar != null);
            EditCommand = new RelayCommand(() => carMenuLogic.Edit(SelectedCar), () => SelectedCar != null);

            Messenger.Register<CarControlVM, string, string>(this, "BasicChannel", (recipient, msg) =>
            {
                OnPropertyChanged("MechanicIds");
            });

        }
    }
}
