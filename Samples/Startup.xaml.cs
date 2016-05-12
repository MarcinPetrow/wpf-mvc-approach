using MVCinWPF;
using MVCinWPF.Core;
using Samples.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Samples
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup
    {
        
        [STAThread]
        public static void Main()
        {
            MVCApplication app = new MVCApplication();

            TimerController timeController = new TimerController();
            app.RegisterController(timeController);

            timeController.Index();

            app.Run();            
        }

        
    }
}
