using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoundsCalculator
{
    public class StatComponent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _value = 0;
        private string _name = "";

        public int Value {
            get => _value;
            set {
                    _value = value;
                    OnPropertyChanged("Value");
                }
        }

        public string Name { get => _name; set => _name = value; }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public StatComponent(string name)
        {
            _name = name;
        }
    }
}
