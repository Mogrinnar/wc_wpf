using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WoundsCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ObservableCollection<Calculation> _calculations = new ObservableCollection<Calculation>();
        public ObservableCollection<Calculation> Calculations { get => _calculations; set => _calculations = value; }

        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadStatsData();
            MainWindow mainWindow = new MainWindow(this);
            mainWindow.Show();
        }

        private void LoadStatsData()
        {
            var amount = new StatComponent("Amount");
            var bs = new StatComponent("BS");
            var strength = new StatComponent("Strength");
            var ap = new StatComponent("AP");

            var list = new List<StatComponent> { amount, bs, strength, ap };
            var attackerComponent = new ActorComponent("Attacker", list);

            Calculations.Add(new Calculation());
        }
    }
}
