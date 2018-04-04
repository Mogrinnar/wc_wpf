using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WoundsCalculator
{
    public class Calculation : INotifyPropertyChanged
    {
        private int _amount = 1;
        private int _bs = 4;
        private int _strength = 4;
        private int _ap = 1;
        private int _damage = 1;
        private int _toughness = 4;
        private int _armourSave = 3;
        private int _invulSave = 5;
        private int _wounds = 1;
        private float _totalWoundAmount;

        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                Calculate();
            }
        }
        public int BS { get => _bs; set
            {
                _bs = value;
                Calculate();
            }
        }
        public int Strength { get => _strength; set
            {
                _strength = value;
                Calculate();
            }
        }
        public int AP { get => _ap;
            set
            {
                _ap = value;
                Calculate();
            }
        }
        public int Damage { get => _damage;
            set
            {
                _damage = value;
                Calculate();
            }
        }
        public int Toughness { get => _toughness;
            set
            {
                _toughness = value;
                Calculate();
            }
        }
        public int ArmourSave { get => _armourSave;
            set
            {
                _armourSave = value;
                Calculate();
            }
        }
        public int InvulSave { get => _invulSave;
            set
            {
                _invulSave = value;
                Calculate();
            }
        }
        public int Wounds { get => _wounds; set
            {
                _wounds = value;
                Calculate();
            }
        }
        public float TotalWoundAmount {
            get => _totalWoundAmount;
            set => _totalWoundAmount = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Calculation()
        {
            Calculate();
        }

        private void Calculate()
        {
            float probToHit = (7 - (float)_bs) / 6;

            float armorFactor = _armourSave + _ap;
            if (_invulSave > armorFactor)
            {
                armorFactor = _invulSave;
            }
            armorFactor = (armorFactor - 1) / 6;

            // prob to wound
            float probToWOund = 0;
            if (_strength == _toughness)
            {
                probToWOund = 1f / 2f; // 4+ roll
            }
            else if (_strength >= (_toughness * 2))
            {
                probToWOund = 5f / 6f; // 2+ roll
            }
            else if ((_strength * 2f) <= (_toughness))
            {
                probToWOund = 1f / 6f; // 6+ roll
            }
            else if (_strength > _toughness)
            {
                probToWOund = 2f / 3f; // 3+ roll
            }
            else if (_strength < _toughness)
            {
                probToWOund = 1f / 3f; // 5+ roll
            }

            float maxDamage = (Damage < 0) ? 0 : (Damage > Wounds) ? Wounds : Damage;

            TotalWoundAmount = probToWOund * _amount * probToHit * armorFactor * maxDamage;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("TotalWoundAmount"));
            }
            

            Console.WriteLine("HandleValueChanged, new Value: " + TotalWoundAmount.ToString());
        }
    }
}
