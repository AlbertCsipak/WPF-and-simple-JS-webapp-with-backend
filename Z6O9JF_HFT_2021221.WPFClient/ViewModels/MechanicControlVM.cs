using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Logic;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class MechanicControlVM : ObservableRecipient
    {
        IMechanicControlLogic mechanicLogic;
        public RestCollection<Mechanic> Mechanics { get; set; }

        private Mechanic selectedMechanic;
        RestService restService;
        public List<int> ServiceIds { get; set; }

        public Mechanic SelectedMechanic
        {
            get { return selectedMechanic; }
            set
            {
                if (value != null)
                {
                    selectedMechanic = new Mechanic()
                    {
                        Name = value.Name,
                        Cars = value.Cars,
                        CarService = value.CarService,
                        MechanicId = value.MechanicId,
                        ServiceId = value.ServiceId
                    };
                    OnPropertyChanged();
                    (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                    (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                    (EditCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        //public ObservableCollection<string> ServiceIds {get { return  } }

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
        public MechanicControlVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<IMechanicControlLogic>())
        {

        }
        public MechanicControlVM(IMechanicControlLogic mechanicLogic)
        {
            this.mechanicLogic = mechanicLogic;
            if (!IsInDesignMode)
            {
                Mechanics = new RestCollection<Mechanic>("http://localhost:11111/", "mechanic","hub");

                mechanicLogic.Setup(Mechanics);
            }
            selectedMechanic = new();

            restService = new("http://localhost:11111/");

            ServiceIds = restService.Get<CarService>("carservice").Select(t => t.TaxNumber).ToList();

            AddCommand = new RelayCommand(() => mechanicLogic.Add(SelectedMechanic), () => SelectedMechanic != null);
            RemoveCommand = new RelayCommand(() => mechanicLogic.Remove(SelectedMechanic), 
                () => restService.Get<Car>("car").Where(t => t.MechanicId == selectedMechanic.MechanicId).Count()==0);
            EditCommand = new RelayCommand(() => mechanicLogic.Edit(SelectedMechanic), () => SelectedMechanic != null);

        }
    }
}
