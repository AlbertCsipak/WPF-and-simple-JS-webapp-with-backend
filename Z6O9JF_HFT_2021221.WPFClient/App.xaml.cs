﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Z6O9JF_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Ioc.Default.ConfigureServices(
            //    new ServiceCollection()
            //    .AddSingleton<IHeroLogic, HeroLogic>()
            //    .AddSingleton<IEditorService, EditorViaWindow>()
            //    .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            //    .BuildServiceProvider()
            //);
        }
    }
}