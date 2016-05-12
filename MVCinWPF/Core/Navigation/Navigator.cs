using MVCinWPF.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MVCinWPF.Core.Navigation
{
    public class Navigator
    {
        public static IController currentController;

        public static void Navigate(Controller controller, Action action, View view) {
            var window = MainWindow.Instance;

            view.DataContext = controller.Data;

            window.NavigateTo(view);

            


        }
    }
}
