using MVCinWPF.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCinWPF.Core
{
    public class Model: IModel
    {
        public static T Create<T>() where T:new()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static T Read<T>() where T : new()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static void Update()
        {
        }

        public static void Delete()
        {
        }
    }
}
