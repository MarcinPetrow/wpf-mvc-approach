using MVCinWPF.Core.Data;
using MVCinWPF.Core.Interfaces;

namespace MVCinWPF.Core
{
    public class Controller : IController
    {
        private dynamic data;

        protected dynamic Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value ?? (Data = new DynamicContext());
            }
        }

        public void ClearData()
        {
            Data = new DynamicContext();
        }
    }
}
