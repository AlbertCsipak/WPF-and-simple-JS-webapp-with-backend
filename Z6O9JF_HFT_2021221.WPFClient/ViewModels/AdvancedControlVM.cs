using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.ViewModels
{
    public class AdvancedControlVM : ObservableRecipient
    {
        public RestService restService { get; set; }
        public ObservableCollection<string> ServiceIncome { get; set; }
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
        //public MainWindowVM() : this(IsInDesignMode ? null : Ioc.Default.GetService<ICarControlLogic>())
        //{

        //}
        public AdvancedControlVM()
        {
            if (!IsInDesignMode)
            {

                var get = restService.Get<KeyValuePair<string, int>>("advanced/serviceincome");

                foreach (var item in get)
                {
                    ServiceIncome.Add(item.Key.ToString() + " " + item.Value.ToString());
                }


            }
        }
    }
}
