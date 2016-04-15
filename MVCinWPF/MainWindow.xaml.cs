using MVCinWPF.Core;
using MVCinWPF.User.Controllers;
using System.ComponentModel;
using System.Windows;

namespace MVCinWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        
        private View currentView;
        public View CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                if (currentView != value)
                {
                    currentView = value;
                    OnPropertyChanged("CurrentView");
                }
            }
        }

        private MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Run() {
            HomeController controller = new HomeController();
            controller.Index();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var localProperyChanged = PropertyChanged;
            if (localProperyChanged != null)
            {
                localProperyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
