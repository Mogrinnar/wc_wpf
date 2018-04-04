using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoundsCalculator
{
    public class ActorComponent : INotifyPropertyChanged
    {
        private string _name;

        public ObservableCollection<StatComponent> StatComponents = new ObservableCollection<StatComponent>();

        public string Name { get => _name; set => _name = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ActorComponent(string name, IEnumerable<StatComponent> statComponents)
        {
            _name = name;
            
            foreach(var stat in statComponents)
            {
                StatComponents.Add(stat);
            }
        }
    }
}
