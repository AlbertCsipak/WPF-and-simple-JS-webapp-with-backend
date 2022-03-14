using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Logic;
using static Z6O9JF_HFT_2021221.Models.Enums;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class BrandControlVM : ObservableRecipient
    {
        IBrandControlLogic brandLogic;
        public RestCollection<Brand> Brands { get; set; }
        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                         Name = value.Name,
                         BrandId = value.BrandId,
                         Cars = value.Cars,
                         Engines = value.Engines,
                         Location = value.Location
                    };
                    OnPropertyChanged();
                    (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                    (EditCommand as RelayCommand).NotifyCanExecuteChanged();
                    (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        RestService restService = new("http://localhost:11111/");
        public bool RemoveaBool
        {
            get
            {
                if (selectedBrand.Name != null)
                {
                    return restService.Get<Car>("car").Where(t => t.BrandId == selectedBrand.BrandId).Count() == 0;
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
        public BrandControlVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<IBrandControlLogic>()) { }
        public BrandControlVM(IBrandControlLogic brandLogic)
        {
            if (!IsInDesignMode)
            {
                this.brandLogic = brandLogic;
                Brands = new RestCollection<Brand>("http://localhost:11111/", "brand", "hub");
                brandLogic.Setup(Brands);

                selectedBrand = new();

                AddCommand = new RelayCommand(() => brandLogic.Add(SelectedBrand), () => SelectedBrand.Name != null);
                RemoveCommand = new RelayCommand(() => brandLogic.Remove(SelectedBrand), () => RemoveaBool);
                EditCommand = new RelayCommand(() => brandLogic.Edit(SelectedBrand), () => SelectedBrand.Name != null);

                Messenger.Register<BrandControlVM, string, string>(this, "BasicChannel", (recipient, msg) =>
                {

                });
            }
        }
    }
}
