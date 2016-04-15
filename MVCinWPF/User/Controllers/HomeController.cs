using MVCinWPF.Core;
using MVCinWPF.Fakes.Models;
using MVCinWPF.User.Models;
using MVCinWPF.User.Views.Home;

namespace MVCinWPF.User.Controllers
{
    public class HomeController: Controller
    {
        public void Index() {
            UserModel model = UserModelFactory.CreateSimpleUser();

            ClearData();
            Data.Name = model.Name;

            IndexView view = new IndexView();
            view.DataContext = Data;

            MainWindow.Instance.CurrentView = view;

        }
    }
}
