using MVCinWPF.Core;
using MVCinWPF.User.Controllers;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;

namespace MVCinWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region Singleton
        private static volatile MainWindow instance;
        private static object syncRoot = new object();

        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null) { 
                            instance = new MainWindow();
                        }
                    }
                }

                return instance;
            }
        }
        #endregion
        
        private MainWindow()
        {
            InitializeComponent();
        }

        public void Start() {
            HomeController controller = new HomeController();
            controller.Index();
        }

        public void NavigateTo(View view)
        {
            Navigate(view);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
