using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using BloombergReader.Model;

namespace BloombergReader.ViewModel
{
    class BarViewModel
    {
        private IList<Bar> _bars;
        public BarViewModel()
        {
            _bars = new List<Bar>
            {
                new Bar { Time = DateTime.Now, Open = 10, High = 20, Low = 5, Close = 6},
                new Bar { Time = DateTime.Now, Open = 20, High = 23, Low = 6, Close = 8}
            };
        }

        public IList<Bar> Bars
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
