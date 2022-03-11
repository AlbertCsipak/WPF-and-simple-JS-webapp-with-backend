using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { SetProperty(ref selectedCar, value); (RemoveCommand as RelayCommand).NotifyCanExecuteChanged(); }
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


        public MainWindowViewModel()
        {
            if (IsInDesignMode is false)
            {
                Cars = new RestCollection<Car>("http://localhost:11111/", "car","hub");
            }



            AddCommand = new RelayCommand(() => Cars.Add(new Car() { OwnerId = 1, BrandId = 1, MechanicId = 1,EngineCode=1 }));

            RemoveCommand = new RelayCommand(()=> Cars.Delete(SelectedCar.Vin), ()=> SelectedCar != null);

        }
    }
}
