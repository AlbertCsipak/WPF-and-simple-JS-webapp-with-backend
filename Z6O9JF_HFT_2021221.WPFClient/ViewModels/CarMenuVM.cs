using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Logic;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class CarMenuVM : ObservableRecipient
    {
        ICarMenuLogic carMenuLogic;
        public RestCollection<Car> Cars { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                SetProperty(ref selectedCar, value); (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public CarMenuVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<ICarMenuLogic>())
        {

        }
        public CarMenuVM(ICarMenuLogic carMenuLogic)
        {
            this.carMenuLogic = carMenuLogic;
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:11111/", "car", "hub");
                carMenuLogic.Setup(Cars);
            }

            AddCommand = new RelayCommand(() => carMenuLogic.Add());
            RemoveCommand = new RelayCommand(() => carMenuLogic.Remove(SelectedCar), () => SelectedCar != null);
            EditCommand = new RelayCommand(() => carMenuLogic.Edit(SelectedCar), () => SelectedCar != null);

        }
    }
}
