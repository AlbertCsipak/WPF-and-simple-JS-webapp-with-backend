using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        public ObservableCollection<int> ServiceIds { get { return new(mechanicLogic.ServiceIds); } }

        RestService restService = new("http://localhost:11111/");
        public bool RemoveaBool
        {
            get
            {
                if (selectedMechanic.Name!=null)
                {
                    return restService.Get<Car>("car").Where(t => t.MechanicId == selectedMechanic.MechanicId).Count() == 0;
                }
                else
                {
                    return false;
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
        public MechanicControlVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<IMechanicControlLogic>()) { }
        public MechanicControlVM(IMechanicControlLogic mechanicLogic)
        {
            this.mechanicLogic = mechanicLogic;
            if (!IsInDesignMode)
            {
                Mechanics = new RestCollection<Mechanic>("http://localhost:11111/", "mechanic", "hub");
                mechanicLogic.Setup(Mechanics);

                selectedMechanic = new();

                AddCommand = new RelayCommand(() => mechanicLogic.Add(SelectedMechanic), () => SelectedMechanic.Name != null);
                RemoveCommand = new RelayCommand(() => mechanicLogic.Remove(SelectedMechanic), () => RemoveaBool);
                EditCommand = new RelayCommand(() => mechanicLogic.Edit(SelectedMechanic), () => SelectedMechanic.Name != null);

                Messenger.Register<MechanicControlVM, string, string>(this, "BasicChannel", (recipient, msg) =>
                {
                    OnPropertyChanged("ServiceIds");
                    OnPropertyChanged("SelectedMechanic");
                });
            }
        }
    }
}
