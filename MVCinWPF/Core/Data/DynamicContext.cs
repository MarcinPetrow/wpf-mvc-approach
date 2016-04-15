using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace MVCinWPF.Core.Data
{
    class DynamicContext : DynamicObject, INotifyPropertyChanged
    {
        Dictionary<string, object> _properties = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();

            return _properties.TryGetValue(name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _properties[binder.Name.ToLower()] = value;
            OnPropertyChanged(binder.Name);

            return true;
        }

        public bool ContainsField(params string[] fieldsNames)
        {
            var result = true;
            if (fieldsNames != null)
            {
                foreach (var field in fieldsNames)
                {
                    result &= _properties.ContainsKey(field);
                }
            }
            return result;
        }
    }
}
