using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using DataModels.Json;
using MultiPointInspection.ViewModels;

namespace MultiPointInspection
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
            Properties.Settings.Default.DefaultInspectionFolder = JsonController.GetJsonFolder();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes().Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override Object GetInstance(Type service, String key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<Object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(Object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnExit(Object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }

        protected override void OnUnhandledException(Object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(sender.ToString());
            base.OnUnhandledException(sender, e);
        }
    }
}
