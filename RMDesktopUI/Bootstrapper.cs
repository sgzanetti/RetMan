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
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //Cuando arranca este proyecto, selecciona 'ShellViewModel' como Base View
            //en Appl.xaml dice que la vista default es StartupUri="MainWindow.xaml"
            //Con esto lo estoy cambiando a ShellViewModel
            DisplayRootViewFor<ShellViewModel>();
        }

    }


}
