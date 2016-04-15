using MVCinWPF.Core;
using MVCinWPF.Core.Interfaces;
using MVCinWPF.User.Models;

namespace MVCinWPF.Fakes.Models
{
    public static class UserModelFactory
    {
        public static UserModel CreateSimpleUser() {
            var model = Model.Create<UserModel>();
            model.Name = "Jenny";
            return model;
        }
    }
}
