using MVCinWPF;
using System.Windows;

namespace MVCinWPF
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e) {
            MainWindow window = MVCinWPF.MainWindow.Instance;
            window.Show();
            window.Run();

            System.Windows.Threading.Dispatcher.Run();
        }
    }
}
