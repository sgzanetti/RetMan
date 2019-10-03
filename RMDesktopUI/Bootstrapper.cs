using Caliburn.Micro;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        // '_container' Contiene la instanciación de clases para el dependency injection
        // todos los 'protected override' son para configurar dependency injection
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            //Esta es la manera que trabaja Caliber.Micro
            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
            //Ahora vamos a conectar los ViewModels con las Views

            // Lo que hace esto es: para cada clase en nuestro proyecto que 
            // termine en 'ViewModel', la registro en mi _container
            // Hay algún quilombo si queremos hacer nUnit test a muestro proyecto
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //Cuando arranca este proyecto, selecciona 'ShellViewModel' como Base View
            //en Appl.xaml dice que la vista default es StartupUri="MainWindow.xaml"
            //Con esto lo estoy cambiando a ShellViewModel
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
