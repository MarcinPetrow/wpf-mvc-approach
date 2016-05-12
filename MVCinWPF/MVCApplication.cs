using MVCinWPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace MVCinWPF
{
    public class MVCApplication : System.Windows.Application
    {
        private List<Controller> controllers;

        public MVCApplication() : base()
        {
            controllers = new List<Controller>();
        }

        public void RegisterController(Controller controller) {
            controllers.Add(controller);
        }

        private void PrepareControllers()
        {
            foreach (var controller in controllers)
            {
                controller.Initialize();
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            PrepareControllers();

            var window = MVCinWPF.MainWindow.Instance;

            MainWindow = window;
            MainWindow.Show();

            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            foreach (var controller in controllers)
            {
                controller.Cleanup();
            }

        }
    }
}
