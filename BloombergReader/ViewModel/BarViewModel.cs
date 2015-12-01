using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BloombergReader.Model;


namespace BloombergReader.ViewModel
{
    class BarViewModel
    {
        private ObservableCollection<Bar> _bars;
        public BarViewModel()
        {
            _bars = new ObservableCollection<Bar>
            {
                new Bar { Time = DateTime.Now, Open = 10, High = 200, Low = 5, Close = 60},
                new Bar { Time = DateTime.Now, Open = 20, High = 230, Low = 6, Close = 80}
            };
        }

        public ObservableCollection<Bar> Bars
        {
            get
            {
                return _bars;
            }
            set
            {
                _bars = value;
            }
        }
    }
}
