using Abp;
using Castle.Facilities.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using T4CodeGenerator.ViewModel;

namespace T4CodeGenerator
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly AbpBootstrapper _bootstrapper;
        private MainWindow _mainWindow;
        public App()
        {
            _bootstrapper = AbpBootstrapper.Create<T4CodeGeneratorWpfUiModule>();
            _bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            
        }
       
        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper.Initialize();

            ViewModelLocator locator = _bootstrapper.IocManager.Resolve<ViewModelLocator>();
            this.Resources.Add("Locator",locator);

            _mainWindow = _bootstrapper.IocManager.Resolve<MainWindow>();
            _mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _bootstrapper.IocManager.Release(_mainWindow);
            _bootstrapper.Dispose();
            base.OnExit(e);
        }
    }
}
