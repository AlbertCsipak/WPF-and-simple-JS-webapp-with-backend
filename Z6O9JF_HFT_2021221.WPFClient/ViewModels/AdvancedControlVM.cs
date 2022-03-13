using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Z6O9JF_HFT_2021221.Models;
using Z6O9JF_HFT_2021221.WPFClient.Logic;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class AdvancedControlVM : ObservableRecipient
    {
        IAdvancedControlLogic advancedControlLogic;
        public ObservableCollection<string> ServiceIncome { get; set; }
        public ObservableCollection<string> MechanicEngineTypes { get; set; }
        public ObservableCollection<string> AVGServiceCost { get; set; }
        public ObservableCollection<string> CarBrandsInService { get; set; }
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
        public AdvancedControlVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<IAdvancedControlLogic>())
        {

        }
        public AdvancedControlVM(IAdvancedControlLogic advancedControlLogic)
        {
            if (!IsInDesignMode)
            {
                this.advancedControlLogic = advancedControlLogic;
                ServiceIncome = new();
                MechanicEngineTypes = new();
                AVGServiceCost = new();
                CarBrandsInService = new();

                advancedControlLogic.Setup(ServiceIncome, MechanicEngineTypes, AVGServiceCost, CarBrandsInService);
            }

        }
    }
}
