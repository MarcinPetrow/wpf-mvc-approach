﻿using MVCinWPF.Core;
using MVCinWPF.Core.Navigation;
using MVCinWPF.Core.Tools;
using MVCinWPF.Fakes.Models;
using MVCinWPF.User.Models;
using MVCinWPF.User.Views.Home;
using System.Windows;

namespace MVCinWPF.User.Controllers
{
    public class HomeController:Controller
    {
        public void Index() {
            UserModel model = UserModelFactory.CreateSimpleUser();

            ClearData();
            Data.Name = model.Name;
            Data.Wii = new DelegateCommand(WiiCommandExecute);

            IndexView view = new IndexView();
            Navigator.Navigate(this, null, view);

        }

        public void WiiCommandExecute(object parameters)
        {
            MessageBox.Show("Wiiii!");
        }       
    }
}
